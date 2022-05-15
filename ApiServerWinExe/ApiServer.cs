using ApiServerWinExe.Controllers;
using ApiServerWinExe.Controllers.Error;
using ApiServerWinExe.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiServerWinExe
{
    /// <summary>簡易サーバ本体</summary>
    public class ApiServer : IDisposable
    {
        /// <summary>送受信イベント情報</summary>
        public class ServerEventArgs : EventArgs
        {
            /// <summary>リクエストメソッド</summary>
            public string Method { get; set; }
            /// <summary>送受信時のヘッダ</summary>
            public NameValueCollection Headers { get; set; }
            /// <summary>リクエスト時のURL</summary>
            public string Url { get; set; }
            /// <summary>送受信コンテンツ</summary>
            public string Body { get; set; }
        }

        /// <summary>リスナー</summary>
        protected LocalHttpListener _listener = new LocalHttpListener();
        /// <summary>Json設定</summary>
        protected JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
        {
            // キャメルケース
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
        };

        /// <summary>Json変換時、インデントを使う</summary>
        public bool PrettyResponse { get; set; } = true;
        /// <summary>受信イベント</summary>
        public event EventHandler<ServerEventArgs> OnRequested;
        /// <summary>応答イベント</summary>
        public event EventHandler<ServerEventArgs> OnResponsed;

        /// <summary>コンストラクタ</summary>
        public ApiServer()
        {
            _listener.OnReceived += _listener_OnReceived;
        }

        /// <summary>Listen開始</summary>
        public void StartListen()
            => _listener?.StartListen();

        /// <summary>Listen停止</summary>
        public void StopListen()
            => _listener?.StopListen();

        /// <summary>受信イベント</summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        private async Task _listener_OnReceived(HttpListenerRequest request, HttpListenerResponse response)
        {
            ControllerFactory factory = ControllerFactory.Instance;
            string[] urlSegments = request.Url.Segments.Select(s => s.TrimEnd('/')).ToArray();
            string requestBody = await request.GetRequestBodyAsync();
            string resourceName = string.Empty;
            dynamic result = null;

            // リクエストがhttp://localhost/Temprary_Listen_Addressesで終わっている場合はエラーとする
            if (urlSegments.Length < 3)
            {
                OnRequested?.Invoke(this, new ServerEventArgs()
                {
                    Method = request.HttpMethod,
                    Headers = request.Headers,
                    Url = "NONE",
                    Body = requestBody,
                });
                result = factory.CreateErrorController(HttpStatusCode.BadRequest);
            }
            else
            {
                resourceName = urlSegments[2];
                OnRequested?.Invoke(this, new ServerEventArgs()
                {
                    Method = request.HttpMethod,
                    Headers = request.Headers,
                    Url = string.Join("/", urlSegments.Skip(2)),
                    Body = requestBody,
                });
                // コントローラを探して実行する
                ControllerBase controller = ControllerFactory.Instance.CreateController(resourceName);
                if (controller != null)
                {
                    controller.SetResponseHeaders(response.Headers);
                    if (request.HttpMethod.ToUpper() == "GET")
                    {
                        result = await OnGetReceivedAsync(request.Headers, urlSegments, requestBody, controller);
                        response.StatusCode = (int)HttpStatusCode.OK;
                    }
                    else if (request.HttpMethod.ToUpper() == "POST")
                    {
                        result = await OnPostReceivedAsync(request.Headers, urlSegments, requestBody, controller);
                        response.StatusCode = (int)HttpStatusCode.OK;
                    }
                    else
                    {
                        // 他のHTTPメソッドは非対応とする
                        // 本当はHEADには必ず対応しなければならないようだがHEADって何？
                        result = factory.CreateErrorController(HttpStatusCode.NotImplemented);
                    }
                    if (result == null)
                    {
                        result = factory.CreateErrorController(HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    result = factory.CreateErrorController(HttpStatusCode.NotFound);
                }
            }
            if (result is ErrorController error)
            {
                response.Headers.Clear();
                error.SetResponseHeaders(response.Headers);
                response.StatusCode = (int)error.StatusCode;
                result = error.OnError(request.Headers, urlSegments, requestBody);
            }
            // 応答出力
            var formatting = PrettyResponse ? Formatting.Indented : Formatting.None;
            var responseBody = JsonConvert.SerializeObject(result, formatting, _jsonSerializerSettings);
            var bytes = Encoding.UTF8.GetBytes(responseBody);

            await response.OutputStream.WriteAsync(bytes, 0, bytes.Length);
            OnResponsed?.Invoke(this, new ServerEventArgs()
            {
                Method = request.HttpMethod,
                Url = string.Join("/", urlSegments.Skip(2)),
                Headers = response.Headers,
                Body = responseBody,
            });
        }

        /// <summary>GETメソッド受信時</summary>
        /// <param name="requestHeaders"></param>
        /// <param name="urlSegments"></param>
        /// <param name="requestBody"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        private async Task<dynamic> OnGetReceivedAsync(NameValueCollection requestHeaders, string[] urlSegments, string requestBody, ControllerBase controller)
        {
            string id = urlSegments.Length > 3 ? urlSegments[3] : null;
            try
            {
                if (controller is IAsyncRead asyncRead)
                {
                    return await asyncRead.ReadAsync(requestHeaders, requestBody, id);
                }
                else if (controller is IRead read)
                {
                    return read.Read(requestHeaders, requestBody, id);
                }
                else
                {
                    //　指定リソースはGETに対応していないのでNotImplemented
                    return ControllerFactory.Instance.CreateErrorController(HttpStatusCode.NotImplemented);
                }
            }
            catch
            {
                // ここでログを吐いたり
            }
            return (dynamic)(null);
        }

        /// <summary>GETメソッド受信時</summary>
        /// <param name="requestHeaders"></param>
        /// <param name="urlSegments"></param>
        /// <param name="requestBody"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        private Task<dynamic> OnPostReceivedAsync(NameValueCollection requestHeaders, string[] urlSegments, string requestBody, ControllerBase controller)
        {
            string method = urlSegments.Last();
            try
            {
                switch (method.ToUpper())
                {
                    case "CREATE":
                        return OnPostCreateReceivedAsync(requestHeaders, urlSegments, requestBody, controller);
                    case "UPDATE":
                        return OnPostUpdateReceivedAsync(requestHeaders, urlSegments, requestBody, controller);
                    case "DELETE":
                        return OnPostDeleteReceivedAsync(requestHeaders, urlSegments, requestBody, controller);
                    default:
                        // CRUD外なのでNotImplemented
                        return Task.FromResult<dynamic>(ControllerFactory.Instance.CreateErrorController(HttpStatusCode.NotImplemented));
                }
            }
            catch
            {
                // ここでログを吐いたり
            }
            return Task.FromResult<dynamic>(null);
        }

        /// <summary>Create</summary>
        /// <param name="requestHeaders"></param>
        /// <param name="urlSegments"></param>
        /// <param name="requestBody"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        private async Task<dynamic> OnPostCreateReceivedAsync(NameValueCollection requestHeaders, string[] urlSegments, string requestBody, ControllerBase controller)
        {
            if (controller is IAsyncCreate asyncCreate)
            {
                return await asyncCreate.CreateAsync(requestHeaders, requestBody);
            }
            else if (controller is ICreate create)
            {
                return create.Create(requestHeaders, requestBody);
            }
            //　指定リソースはCreateに対応していないのでNotImplemented
            return ControllerFactory.Instance.CreateErrorController(HttpStatusCode.NotImplemented);
        }

        /// <summary>Update</summary>
        /// <param name="requestHeaders"></param>
        /// <param name="urlSegments"></param>
        /// <param name="requestBody"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        private async Task<dynamic> OnPostUpdateReceivedAsync(NameValueCollection requestHeaders, string[] urlSegments, string requestBody, ControllerBase controller)
        {
            string id = urlSegments.Length > 3 ? urlSegments[3] : null;
            if (controller is IAsyncUpdate asyncUpdate)
            {
                return await asyncUpdate.UpdateAsync(requestHeaders, requestBody, id);
            }
            else if (controller is IUpdate update)
            {
                return update.Update(requestHeaders, requestBody, id);
            }
            //　指定リソースはUpdateに対応していないのでNotImplemented
            return ControllerFactory.Instance.CreateErrorController(HttpStatusCode.NotImplemented);
        }

        /// <summary>Delete</summary>
        /// <param name="requestHeaders"></param>
        /// <param name="urlSegments"></param>
        /// <param name="requestBody"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        private async Task<dynamic> OnPostDeleteReceivedAsync(NameValueCollection requestHeaders, string[] urlSegments, string requestBody, ControllerBase controller)
        {
            string id = urlSegments.Length > 3 ? urlSegments[3] : null;
            if (controller is IAsyncDelete asyncDelete)
            {
                return await asyncDelete.DeleteAsync(requestHeaders, requestBody, id);
            }
            else if (controller is IDelete delete)
            {
                return delete.Delete(requestHeaders, requestBody, id);
            }
            //　指定リソースはDeleteに対応していないのでNotImplemented
            return ControllerFactory.Instance.CreateErrorController(HttpStatusCode.NotImplemented);
        }

        /// <summary>開放</summary>
        public void Dispose()
        {
            _listener?.Dispose();
        }
    }
}
