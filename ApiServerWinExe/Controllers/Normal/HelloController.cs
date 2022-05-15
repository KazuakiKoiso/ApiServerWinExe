using ApiServerWinExe.Controllers.Attributes;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace ApiServerWinExe.Controllers.Normal
{
    /// <summary>Hello</summary>
    [Controller("Hello")]
    public class HelloController : ControllerBase, IAsyncRead
    {
        public Task<dynamic> ReadAsync(NameValueCollection headers, string requestBody, string id)
        {
            return Task.Run<dynamic>(() =>
            {
                var body = new { Name = string.Empty };
                body = JsonConvert.DeserializeAnonymousType(requestBody, body);
                if (string.IsNullOrEmpty(body?.Name))
                {
                    return new
                    {
                        Message = "こんにちは！",
                    };
                }
                else
                {
                    return new
                    {
                        Message = $"こんにちは、{body?.Name}さん！",
                    };
                }
            });
        }
    }
}
