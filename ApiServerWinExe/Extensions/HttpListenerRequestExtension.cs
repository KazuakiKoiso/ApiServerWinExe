using System.Net;
using System.Threading.Tasks;
using System;
using System.IO;

namespace ApiServerWinExe.Extensions
{
    public static class HttpListenerRequestExtension
    {
        public static async Task<string> GetRequestBodyAsync(this HttpListenerRequest @this)
        {
            using (var sr = new StreamReader(@this.InputStream))
            {
                return await sr.ReadToEndAsync();
            }
        }

        public static string GetRequestBody(this HttpListenerRequest @this)
        {
            using (var sr = new StreamReader(@this.InputStream))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
