using ApiServerWinExe.Controllers.Attributes;
using ApiServerWinExe.Models;
using System.Collections.Specialized;
using System.Net;

namespace ApiServerWinExe.Controllers.Error
{
    /// <summary>404 Not Found</summary>
    [ErrorController(HttpStatusCode.NotFound)]
    public class NotFoundErrorController : ErrorController
    {
        /// <summary>ステータスコード</summary>
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        /// <summary>エラーレスポンス処理</summary>
        /// <param name="requestHeaders">リクエストヘッダ</param>
        /// <param name="urlSegments">リクエストURL</param>
        /// <param name="requestBody">リクエストボディ</param>
        /// <returns>エラーオブジェクト</returns>
        public override dynamic OnError(NameValueCollection requestHeaders, string[] urlSegments, string requestBody)
            => new ErrorResult()
            {
                Code = (int)StatusCode,
                Message = $"リソースが見つかりません。({urlSegments[1]})",
            };
    }
}