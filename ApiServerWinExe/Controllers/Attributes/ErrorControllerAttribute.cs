using System;
using System.Net;

namespace ApiServerWinExe.Controllers.Attributes
{
    /// <summary>エラーコントローラに添付する属性</summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ErrorControllerAttribute : Attribute
    {
        /// <summary>Httpコード</summary>
        public HttpStatusCode StatusCode { get; }
        public ErrorControllerAttribute(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
