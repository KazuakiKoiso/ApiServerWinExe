using ApiServerWinExe.Controllers.Attributes;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace ApiServerWinExe.Controllers.Normal
{
    /// <summary>Heavy</summary>
    [Controller("Heavy")]
    public class HeavyController : ControllerBase , IAsyncRead
    {
        public async Task<dynamic> ReadAsync(NameValueCollection headers, string requestBody, string id)
        {
            var body = new { Time = (int?)0 };
            body = JsonConvert.DeserializeAnonymousType(requestBody, body);
            await Task.Delay(body?.Time ?? 10000);
            return new
            {
                Message = "おまたせ！",
            };
        }
    }
}
