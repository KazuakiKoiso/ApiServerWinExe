using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using ApiServerWinExe.Controllers.Attributes;
using ApiServerWinExe.Extensions;

namespace ApiServerWinExe.Controllers.Normal
{
    /// <summary>Heavy</summary>
    [Controller("Heavy")]
    public class HeavyController : ControllerBase, IAsyncRead
    {
        /// <summary>Get</summary>
        /// <param name="headers">リクエストヘッダ</param>
        /// <param name="urlSegments">URL</param>
        /// <returns>処理結果</returns>
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
