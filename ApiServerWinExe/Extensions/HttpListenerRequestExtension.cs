using System.Net;
using System.Threading.Tasks;
using System;
using System.IO;

namespace ApiServerWinExe.Extensions
{
    public static class HttpListenerRequestExtension
    {
        public static Task<string> GetRequestBodyAsync(this HttpListenerRequest @this)
        {
            using (StreamReader sr = new StreamReader(@this.InputStream))
            {
                return sr.ReadToEndAsync();
            }
        }

        public static string GetRequestBody(this HttpListenerRequest @this)
        {
            using (StreamReader sr = new StreamReader(@this.InputStream))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
