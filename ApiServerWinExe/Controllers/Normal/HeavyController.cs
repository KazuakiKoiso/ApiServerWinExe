using ApiServerWinExe.Extensions;
using ApiServerWinExe.Controllers.Attributes;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServerWinExe.Controllers.Normal
{
    /// <summary>Heavy</summary>
    [Controller("Heavy")]
    public class HeavyController : ControllerBase, IAsyncRead
    {
        public async Task<dynamic> ReadAsync(NameValueCollection headers, string[] urlSegments)
        {
            var delayTime = urlSegments.FirstOrDefault();
            await Task.Delay(delayTime?.IsNumeric() == true ? delayTime.ToInt() : 10000);
            return new
            {
                Message = "おまたせ！",
            };
        }
    }
}
