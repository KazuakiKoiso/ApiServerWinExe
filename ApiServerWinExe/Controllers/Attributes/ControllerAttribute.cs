using System;

namespace ApiServerWinExe.Controllers.Attributes
{
    /// <summary>コントローラクラスに添付する属性</summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ControllerAttribute : Attribute
    {
        public string ResourceName { get; }

        public ControllerAttribute(string resourceName)
        {
            ResourceName = resourceName;
        }
    }
}
