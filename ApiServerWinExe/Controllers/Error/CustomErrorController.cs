using System.Collections.Specialized;
using System.Net;
using ApiServerWinExe.Models;

namespace ApiServerWinExe.Controllers.Error
{
    /// <summary>
    /// <para>ControllerFactoryを介さずに直接使うエラーコントローラ</para>
    /// <para>コンストラクタで独自の応答メッセージを指定する</para>
    /// </summary>
    class CustomErrorController : ErrorController
    {
        /// <summary>ステータスコード</summary>
        public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        /// <summary>エラーメッセージ</summary>
        private readonly string _message;

        /// <summary>コンストラクタ</summary>
        /// <param name="message">エラーメッセージ</param>
        public CustomErrorController(string message)
        {
            _message = message;
        }

        /// <summary>エラーレスポンス処理</summary>
        /// <param name="requestHeaders">リクエストヘッダ</param>
        /// <param name="urlSegments">リクエストURL</param>
        /// <param name="requestBody">リクエストボディ</param>
        /// <returns>エラーオブジェクト</returns>
        public override dynamic OnError(NameValueCollection requestHeaders, string[] urlSegments, string requestBody)
            => new ErrorResult()
            {
                Code = (int)StatusCode,
                Message = _message,
            };
    }
}
