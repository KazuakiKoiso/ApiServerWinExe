using ApiServerWinExe.Controllers.Attributes;
using ApiServerWinExe.Models;
using System.Collections.Specialized;
using System.Net;

namespace ApiServerWinExe.Controllers.Error
{
    /// <summary>500 InternalServerError</summary>
    [ErrorController(HttpStatusCode.InternalServerError)]
    public class InternalServerErrorController : ErrorController
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
        /// <summary>エラーレスポンス処理</summary>
        /// <param name="requestHeaders">リクエストヘッダ</param>
        /// <param name="urlSegments">リクエストURL</param>
        /// <param name="requestBody">リクエストボディ</param>
        /// <returns></returns>
        public override dynamic OnError(NameValueCollection requestHeaders, string[] urlSegments, string requestBody)
            => new ErrorResult()
            {
                Code = (int)StatusCode,
                Message = "サーバで不明なエラーが発生しました。",
            };
    }
}
