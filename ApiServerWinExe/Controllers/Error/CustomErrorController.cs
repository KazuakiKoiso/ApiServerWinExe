using ApiServerWinExe.Models;
using System.Collections.Specialized;
using System.Net;

namespace ApiServerWinExe.Controllers.Error
{
    /// <summary>
    /// <para>ControllerFactoryを介さずに直接使うエラーコントローラ</para>
    /// <para>コンストラクタで独自の応答メッセージを指定する</para>
    /// </summary>
    class CustomErrorController : ErrorController
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        private readonly string _message;

        /// <summary>コンストラクタで</summary>
        /// <param name="message"></param>
        public CustomErrorController(string message)
        {
            _message = message;
        }

        /// <summary>エラーレスポンス処理</summary>
        /// <param name="requestHeaders">リクエストヘッダ</param>
        /// <param name="urlSegments">リクエストURL</param>
        /// <param name="requestBody">リクエストボディ</param>
        /// <returns></returns>
        public override dynamic OnError(NameValueCollection requestHeaders, string[] urlSegments, string requestBody)
            => new ErrorResult()
            {
                Code = (int)StatusCode,
                Message = _message,
            };
    }
}
