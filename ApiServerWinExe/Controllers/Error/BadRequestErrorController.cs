using ApiServerWinExe.Controllers.Attributes;
using ApiServerWinExe.Models;
using System.Collections.Specialized;
using System.Net;

namespace ApiServerWinExe.Controllers.Error
{
    /// <summary>400 Bad Request</summary>
    [ErrorController(HttpStatusCode.BadRequest)]
    public class BadRequestErrorController : ErrorController
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        /// <summary>エラーレスポンス処理</summary>
        /// <param name="requestHeaders">リクエストヘッダ</param>
        /// <param name="urlSegments">リクエストURL</param>
        /// <param name="requestBody">リクエストボディ</param>
        /// <returns></returns>
        public override dynamic OnError(NameValueCollection requestHeaders, string[] urlSegments, string requestBody)
            => new ErrorResult()
            {
                Code = (int)StatusCode,
                Message = "リクエストが不正です。",
            };
    }
}
