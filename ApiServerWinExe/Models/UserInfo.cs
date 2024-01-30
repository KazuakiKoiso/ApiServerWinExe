namespace ApiServerWinExe.Models
{
    /// <summary>ユーザ情報</summary>
    public class UserInfo
    {
        /// <summary>ユーザID</summary>
        public int? Id { get; set; }

        /// <summary>ユーザ名</summary>
        public string Name { get; set; }

        /// <summary>メールアドレス</summary>
        public string Mail { get; set; }
    }
}