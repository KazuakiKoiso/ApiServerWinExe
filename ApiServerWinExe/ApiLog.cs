using System;
using System.Collections.Specialized;

namespace ApiServerWinExe
{
    public enum Direction
    {
        Received = 0,
        Responsed,
    }
    public class ApiLog
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public Direction Direction { get; set; }
        public string Method { get; set; }
        public NameValueCollection Headers { get; set; }
        public string Resource { get; set; }
        public string Ip { get; set; }
        public string Body { get; set; }
    }
}
