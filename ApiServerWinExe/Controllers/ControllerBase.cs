using System.Net;
using System.Linq;

namespace ApiServerWinExe.Controllers
{
    /// <summary>コントローラの基底クラス</summary>
    public class ControllerBase
    {
        /// <summary>レスポンスヘッダーを設定する</summary>
        /// <param name="response"></param>
        public virtual void SetResponseHeaders(WebHeaderCollection headers)
        {
            if (!headers.AllKeys.Contains("Content-Type"))
            {
                headers.Add("Content-Type:application/json; charaset=utf8");
                headers.Add("Access-Control-Allow-Origin: *");
            }
        }
    }
}
