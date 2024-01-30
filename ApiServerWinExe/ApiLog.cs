using System;
using System.Collections.Specialized;

namespace ApiServerWinExe
{
    /// <summary>方向</summary>
    public enum Direction
    {
        /// <summary>要求</summary>
        Received = 0,

        /// <summary>応答</summary>
        Responsed,
    }

    /// <summary>Apiログ</summary>
    public class ApiLog
    {
        /// <summary>ID</summary>
        public int Id { get; set; }

        /// <summary>日時</summary>
        public DateTime Timestamp { get; set; }

        /// <summary>方向</summary>
        public Direction Direction { get; set; }

        /// <summary>HTTPメソッド</summary>
        public string Method { get; set; }

        /// <summary>要求/応答ヘッダ</summary>
        public NameValueCollection Headers { get; set; }

        /// <summary>リソース名</summary>
        public string Resource { get; set; }

        /// <summary>IPアドレス</summary>
        public string Ip { get; set; }

        /// <summary>要求/応答ボディ</summary>
        public string Body { get; set; }
    }
}