using System;

namespace ApiServerWinExe.Users
{
    /// <summary>ユーザ処理関連の例外</summary>
    public class UserException : Exception
    {
        /// <summary>ユーザ情報</summary>
        public UserData User { get; set; }

        /// <summary>コンストラクタ</summary>
        /// <param name="user">ユーザ情報</param>
        /// <param name="message">エラーメッセージ</param>
        public UserException(UserData user, string message)
            : base(message)
        {
            User = user;
        }
    }

    /// <summary>ユーザ追加時の例外</summary>
    public class AddUserException : UserException
    {
        /// <summary>コンストラクタ</summary>
        /// <param name="user">ユーザ情報</param>
        public AddUserException(UserData user)
            : base(user, $"指定のユーザIDは既に登録されています。({user.Id})")
        {
        }
    }

    /// <summary>ユーザ不在例外</summary>
    public class UserNotExistException : UserException
    {
        /// <summary>コンストラクタ</summary>
        /// <param name="userId">ユーザID</param>
        public UserNotExistException(int userId)
            : base(new UserData() { Id = userId }, $"対象ユーザが存在しません。({userId})")
        {
        }
    }
}