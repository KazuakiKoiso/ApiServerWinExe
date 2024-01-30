using ApiServerWinExe.Controllers.Attributes;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServerWinExe.Controllers.Normal
{
    /// <summary>Hello</summary>
    [Controller("Hello")]
    public class HelloController : ControllerBase, IRead
    {
        public dynamic Read(NameValueCollection headers, string[] urlSegments)
        {
            var name = urlSegments.FirstOrDefault();
            return string.IsNullOrEmpty(name) ? (new { Message = "こんにちは！" }) : (dynamic)(new { Message = $"こんにちは！{name}さん！" });
        }
    }
}
