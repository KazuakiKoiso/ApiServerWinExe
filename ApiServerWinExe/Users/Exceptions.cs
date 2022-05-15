using System;

namespace ApiServerWinExe.Users
{
    public class UserException : Exception
    {
        public UserData User { get; set; }
        public UserException(UserData user, string message)
            : base(message)
        {
            User = user;
        }
    }

    public class AddUserException : UserException
    {
        public AddUserException(UserData user)
            : base(user, $"指定のユーザIDは既に登録されています。({user.Id})")
        {
        }
    }

    public class UserNotExistException : UserException
    {
        public UserNotExistException(int userId)
            : base(new UserData() { Id = userId }, $"対象ユーザが存在しません。({userId})")
        {
        }
    }
}
