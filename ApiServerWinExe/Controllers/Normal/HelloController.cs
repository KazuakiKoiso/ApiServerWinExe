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
            if (string.IsNullOrEmpty(name))
            {
                return new { Message = "こんにちは！" };
            }
            else
            {
                return new { Message = $"こんにちは！{name}さん！" };
            }
        }
    }
}
