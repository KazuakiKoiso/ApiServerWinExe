using ApiServerWinExe.Controllers.Attributes;
using ApiServerWinExe.Models;
using System.Collections.Specialized;
using System.Net;

namespace ApiServerWinExe.Controllers.Error
{
    /// <summary>406 Not Acceptable</summary>
    [ErrorController(HttpStatusCode.NotAcceptable)]
    public class NotAcceptableErrorController : ErrorController
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.NotAcceptable;

        /// <summary>エラーレスポンス処理</summary>
        /// <param name="requestHeaders">リクエストヘッダ</param>
        /// <param name="urlSegments">リクエストURL</param>
        /// <param name="requestBody">リクエストボディ</param>
        /// <returns></returns>
        public override dynamic OnError(NameValueCollection requestHeaders, string[] urlSegments, string requestBody)
            => new ErrorResult()
            {
                Code = (int)StatusCode,
                Message = "許可されていない操作です。",
            };
    }
}
