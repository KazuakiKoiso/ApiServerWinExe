using ApiServerWinExe.Controllers;
using ApiServerWinExe.Controllers.Attributes;
using System;
using System.Reflection;

namespace ApiServerWinExe.Extensions
{
    public static class ControllerExtension
    {
        public static string GetResourceName(this ControllerBase @this)
            => @this.GetType().GetCustomAttribute<ControllerAttribute>()?.ResourceName;
    }
}
