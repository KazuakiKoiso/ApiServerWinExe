using System.Collections.Specialized;
using System.Linq;
using ApiServerWinExe.Controllers.Attributes;
using ApiServerWinExe.Controllers.Error;
using ApiServerWinExe.Extensions;
using ApiServerWinExe.Models;
using ApiServerWinExe.Users;
using Newtonsoft.Json;

namespace ApiServerWinExe.Controllers.Normal
{
    /// <summary>ユーザ情報コントローラ</summary>
    [Controller("User")]
    public class UserController : ControllerBase, ICRUD
    {
        /// <summary>ユーザ登録</summary>
        /// <param name="headers"></param>
        /// <param name="requestBody"></param>
        /// <returns>処理結果</returns>
        public dynamic Create(NameValueCollection headers, string requestBody)
        {
            var info = JsonConvert.DeserializeObject<UserInfo>(requestBody);
            if (!info.Id.HasValue ||
                string.IsNullOrEmpty(info.Name) ||
                string.IsNullOrEmpty(info.Mail))
            {
                return new BadRequestErrorController();
            }

            var newUser = new UserData()
            {
                Id = info.Id.Value,
                Name = info.Name,
                Mail = info.Mail,
            };
            try
            {
                UserRepository.Instance.AddUser(newUser);
            }
            catch (AddUserException ex)
            {
                return new CustomErrorController(ex.Message);
            }
            return newUser;
        }

        /// <summary>ユーザ取得</summary>
        /// <param name="headers">リクエストヘッダ</param>
        /// <param name="urlSegments">URL</param>
        /// <returns>処理結果</returns>
        public dynamic Read(NameValueCollection headers, string[] urlSegments)
        {
            var id = urlSegments.FirstOrDefault();
            if (string.IsNullOrEmpty(id))
            {
                return UserRepository.Instance.GetUsers().OrderBy(u => u.Id);
            }
            else
            {
                if (!id.IsNumeric())
                {
                    return new BadRequestErrorController();
                }
                try
                {
                    return UserRepository.Instance.GetUser(int.Parse(id));
                }
                catch (UserNotExistException ex)
                {
                    return new CustomErrorController(ex.Message);
                }
            }
        }

        /// <summary>ユーザ更新</summary>
        /// <param name="headers">リクエストヘッダ</param>
        /// <param name="requestBody">リクエストボディ</param>
        /// <param name="id">ユーザID</param>
        /// <returns>処理結果</returns>
        public dynamic Update(NameValueCollection headers, string requestBody, string id)
        {
            var info = JsonConvert.DeserializeObject<UserInfo>(requestBody);
            if (!id.IsNumeric() || string.IsNullOrEmpty(info.Name) || string.IsNullOrEmpty(info.Mail))
            {
                return new BadRequestErrorController();
            }
            var updateUser = new UserData()
            {
                Id = int.Parse(id),
                Name = info.Name,
                Mail = info.Mail,
            };
            try
            {
                UserRepository.Instance.UpdateUser(updateUser);
            }
            catch (UserNotExistException ex)
            {
                return new CustomErrorController(ex.Message);
            }
            return updateUser;
        }

        /// <param name="headers">リクエストヘッダ</param>
        /// <param name="requestBody">リクエストボディ</param>
        /// <param name="id">ユーザID</param>
        /// <returns>処理結果</returns>
        public dynamic Delete(NameValueCollection headers, string requestBody, string id)
        {
            if (!id.IsNumeric())
            {
                return new BadRequestErrorController();
            }
            try
            {
                UserRepository.Instance.DeleteUser(id.ToInt());
                // HttpStatusが200であればよいので戻り値なし
                // nullを返すわけにはいかないので空のオブジェクトを返しておく
                return new { };
            }
            catch (UserNotExistException ex)
            {
                return new CustomErrorController(ex.Message);
            }
        }
    }
}