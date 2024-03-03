using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ApiServerWinExe.Extensions
{
    /// <summary>HttpListenerRequestの拡張メソッド</summary>
    public static class HttpListenerRequestExtension
    {
        /// <summary>リクエストボディを取得する</summary>
        /// <param name="this"><see cref="HttpListenerRequest"/></param>
        /// <returns>リクエストボディ</returns>
        public static async Task<string> GetRequestBodyAsync(this HttpListenerRequest @this)
        {
            using (var sr = new StreamReader(@this.InputStream))
            {
                return await sr.ReadToEndAsync();
            }
        }

        /// <summary>リクエストボディを取得する</summary>
        /// <param name="this"><see cref="HttpListenerRequest"/></param>
        /// <returns>リクエストボディ</returns>
        public static string GetRequestBody(this HttpListenerRequest @this)
        {
            using (var sr = new StreamReader(@this.InputStream))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
