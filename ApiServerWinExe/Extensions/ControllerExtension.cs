using System.Reflection;
using ApiServerWinExe.Controllers;
using ApiServerWinExe.Controllers.Attributes;

namespace ApiServerWinExe.Extensions
{
    /// <summary>コントローラの拡張メソッド</summary>
    public static class ControllerExtension
    {
        /// <summary>リソース名を取得する</summary>
        /// <param name="this">コントローラ</param>
        /// <returns>リソース名</returns>
        public static string GetResourceName(this ControllerBase @this)
            => @this.GetType().GetCustomAttribute<ControllerAttribute>()?.ResourceName;
    }
}
