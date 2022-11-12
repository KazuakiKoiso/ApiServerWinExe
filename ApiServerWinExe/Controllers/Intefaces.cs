using System.Collections.Specialized;
using System.Threading.Tasks;

namespace ApiServerWinExe.Controllers
{
    /// <summary>
    /// コントローラがCreateに対応していることを表す
    /// <![CDATA[
    /// /name/create
    /// ]]>
    /// </summary>
    public interface ICreate
    {
        dynamic Create(NameValueCollection headers, string requestBody);
    }

    /// <summary>
    /// コントローラがCreateに対応していることを表す（非同期）
    /// <![CDATA[
    /// /name/create
    /// ]]>
    /// </summary>
    public interface IAsyncCreate
    {
        Task<dynamic> CreateAsync(NameValueCollection headers, string requestBody);
    }

    /// <summary>
    /// コントローラがReadに対応していることを表す
    /// <![CDATA[
    /// /name/id
    /// ]]>
    /// </summary>
    public interface IRead
    {
        dynamic Read(NameValueCollection headers, string[] urlSegments);
    }

    /// <summary>
    /// コントローラがReadに対応していることを表す（非同期）
    /// <![CDATA[
    /// /name/id
    /// ]]>
    /// </summary>
    public interface IAsyncRead
    {
        Task<dynamic> ReadAsync(NameValueCollection headers, string[] urlSegments);
    }

    /// <summary>
    /// コントローラがUpdateに対応していることを表す
    /// <![CDATA[
    /// /name/id/update
    /// ]]>
    /// </summary>
    public interface IUpdate
    {
        dynamic Update(NameValueCollection headers, string requestBody, string id);
    }

    /// <summary>
    /// コントローラがUpdateに対応していることを表す（非同期）
    /// <![CDATA[
    /// /name/id/update
    /// ]]>
    /// </summary>
    public interface IAsyncUpdate
    {
        Task<dynamic> UpdateAsync(NameValueCollection headers, string requestBody, string id);
    }

    /// <summary>
    /// コントローラがDeleteに対応していることを表す
    /// <![CDATA[
    /// /name/id/delete
    /// ]]>
    /// </summary>
    public interface IDelete
    {
        dynamic Delete(NameValueCollection headers, string requestBody, string id);
    }

    /// <summary>
    /// コントローラがDeleteに対応していることを表す（非同期）
    /// <![CDATA[
    /// /name/id/delete
    /// ]]>
    /// </summary>
    public interface IAsyncDelete
    {
        Task<dynamic> DeleteAsync(NameValueCollection headers, string requestBody, string id);
    }

    /// <summary>コントローラがCRUD全てに対応していることを表す</summary>
    public interface ICRUD : ICreate, IRead, IUpdate, IDelete
    {
    }

    /// <summary>コントローラがCRUD全てに対応していることを表す（非同期）</summary>
    public interface IAsyncCRUD : IAsyncCreate, IAsyncRead, IAsyncUpdate, IAsyncDelete
    {
    }
}
