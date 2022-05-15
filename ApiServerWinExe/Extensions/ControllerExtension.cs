using ApiServerWinExe.Controllers;
using ApiServerWinExe.Controllers.Attributes;
using System;
using System.Reflection;

namespace ApiServerWinExe.Extensions
{
    public static class ControllerExtension
    {
        public static string GetResourceName(this ControllerBase @this)
        {
            Type t = @this.GetType();
            ControllerAttribute attr = t.GetCustomAttribute<ControllerAttribute>();
            return attr?.ResourceName;
        }
    }
}
