using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiServerWinExe.Users
{
    /// <summary>ユーザ情報DB的なやつ</summary>
    public class UserRepository
    {
        // シングルトン
        private static Lazy<UserRepository> _instance = new Lazy<UserRepository>(() => new UserRepository());
        public static UserRepository Instance => _instance.Value;

        /// <summary>データベース本体</summary>
        private List<UserData> _users = new List<UserData>();

        /// <summary>データ追加イベント</summary>
        public event EventHandler<UserData> UserAdded;

        /// <summary>データ更新イベント</summary>
        public event EventHandler<UserData> UserUpdated;

        /// <summary>データ削除イベント</summary>
        public event EventHandler<int> UserDeleted;

        /// <summary>コンストラクタ</summary>
        private UserRepository()
        {
            // データベース初期値
            _users.AddRange(new UserData[]
            {
                new UserData(){ Id=1, Name="ユーザ1", Mail="User1@user.co.jp" },
                new UserData(){ Id=2, Name="ユーザ2", Mail="User2@user.co.jp" },
                new UserData(){ Id=3, Name="ユーザ3", Mail="User3@user.co.jp" },
                new UserData(){ Id=4, Name="ユーザ4", Mail="User4@user.co.jp" },
            });
        }

        /// <summary>ユーザリスト取得</summary>
        /// <returns>読取専用ユーザリスト</returns>
        public IReadOnlyCollection<UserData> GetUsers()
            => _users;

        /// <summary>ユーザ情報取得</summary>
        /// <param name="userId">ユーザID</param>
        /// <returns>ユーザ情報</returns>
        public UserData GetUser(int userId)
        {
            if (!_users.Any(u => u.Id == userId))
            {
                throw new UserNotExistException(userId);
            }
            UserData user = _users.First(u => u.Id == userId);

            // コピーを返すことでReadOnly的なものを実現
            return new UserData()
            {
                Id = user.Id,
                Name = user.Name,
                Mail = user.Mail,
            };
        }
        /// <summary>ユーザ追加</summary>
        /// <param name="newUser">新規ユーザ</param>
        public void AddUser(UserData newUser)
        {
            if(_users.Any(u => u.Id == newUser.Id))
            {
                throw new AddUserException(newUser);
            }
            _users.Add(newUser);
            UserAdded?.Invoke(this, newUser);
        }

        /// <summary>ユーザ更新</summary>
        /// <param name="user">ユーザ情報</param>
        public void UpdateUser(UserData user)
        {
            if (!_users.Any(u => u.Id == user.Id))
            {
                throw new UserNotExistException(user.Id);
            }
            UserData record = _users.First(u => u.Id == user.Id);
            record.Name = user.Name;
            record.Mail = user.Mail;
            UserUpdated?.Invoke(this, user);
        }

        /// <summary>ユーザ削除</summary>
        /// <param name="userId">ユーザID</param>
        public void DeleteUser(int userId)
        {
            if (!_users.Any(u => u.Id == userId))
            {
                throw new UserNotExistException(userId);
            }
            _users.Remove(_users.First(u => u.Id == userId));
            UserDeleted?.Invoke(this, userId);
        }
    }
}
