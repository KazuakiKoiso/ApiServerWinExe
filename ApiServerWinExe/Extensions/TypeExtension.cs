using System;

namespace ApiServerWinExe.Extensions
{
    /// <summary><see cref="Type"/>の拡張メソッド</summary>
    public static class TypeExtension
    {
        /// <summary>publicで指定の名称のプロパティの有無を確認する</summary>
        /// <typeparam name="T">ジェネリクス型</typeparam>
        /// <param name="this">対象Type</param>
        /// <param name="name">プロパティ名称</param>
        /// <returns>プロパティの有無</returns>
        public static bool HasPublicProperty<T>(this Type @this, string name)
            => @this.GetProperty(name, typeof(T)) != null;
    }
}
