using System.Collections.Specialized;
using System.Net;

namespace ApiServerWinExe.Controllers.Error
{
    /// <summary>エラー時のレスポンスを制御するクラスの基底クラス</summary>
    public abstract class ErrorController : ControllerBase
    {
        /// <summary>ステータスコード</summary>
        public abstract HttpStatusCode StatusCode { get; }
        public abstract dynamic OnError(NameValueCollection requestHeaders, string[] urlSegments, string requestBody);
    }
}
