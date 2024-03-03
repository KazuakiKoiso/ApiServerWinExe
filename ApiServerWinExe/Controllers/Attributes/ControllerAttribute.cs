using System;

namespace ApiServerWinExe.Controllers.Attributes
{
    /// <summary>コントローラクラスに添付する属性</summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ControllerAttribute : Attribute
    {
        /// <summary>リソース名</summary>
        public string ResourceName { get; }

        /// <summary>コンストラクタ</summary>
        /// <param name="resourceName">リソース名</param>
        public ControllerAttribute(string resourceName)
        {
            ResourceName = resourceName;
        }
    }
}
