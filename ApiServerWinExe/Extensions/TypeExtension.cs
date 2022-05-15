using System;

namespace ApiServerWinExe.Extensions
{
    public static class TypeExtension
    {
        public static bool HasPublicProperty<T>(this Type @this, string name)
            => @this.GetProperty(name, typeof(T)) != null;
    }
}
