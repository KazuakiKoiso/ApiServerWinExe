namespace ApiServerWinExe.Models
{
    /// <summary>エラーレスポンス用オブジェクト</summary>
    public class ErrorResult
    {
        /// <summary>エラーコード</summary>
        public int Code { get; set; }

        /// <summary>エラーメッセージ</summary>
        public string Message { get; set; }
    }
}