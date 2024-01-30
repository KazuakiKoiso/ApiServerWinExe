using System.Collections.Specialized;
using System.Linq;
using ApiServerWinExe.Controllers.Attributes;

namespace ApiServerWinExe.Controllers.Normal
{
    /// <summary>Hello</summary>
    [Controller("Hello")]
    public class HelloController : ControllerBase, IRead
    {
        /// <summary>Get</summary>
        /// <param name="headers">リクエストヘッダ</param>
        /// <param name="urlSegments">URL</param>
        /// <returns>処理結果</returns>
        public dynamic Read(NameValueCollection headers, string[] urlSegments)
        {
            var name = urlSegments.FirstOrDefault();
            return string.IsNullOrEmpty(name) ? (new { Message = "こんにちは！" }) : (dynamic)(new { Message = $"こんにちは！{name}さん！" });
        }
    }
}
