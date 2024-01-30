using ApiServerWinExe.Controllers.Attributes;
using ApiServerWinExe.Controllers.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;

namespace ApiServerWinExe.Controllers
{
    /// <summary>コントローラオブジェクトのファクトリ</summary>
    public class ControllerFactory
    {
        /// <summary>シングルトンインスタンス</summary>
        private static readonly Lazy<ControllerFactory> _instance = new Lazy<ControllerFactory>(() => new ControllerFactory());

        /// <summary>シングルトンインスタンス</summary>
        public static ControllerFactory Instance => _instance.Value;

        /// <summary>コントローラの型情報</summary>
        private readonly Dictionary<string, Type> _controllers;

        /// <summary>エラー時コントローラの型情報</summary>
        private readonly Dictionary<HttpStatusCode, Type> _errorControllers;

        /// <summary>コンストラクタ</summary>
        private ControllerFactory()
        {
            var definedTypes = Assembly.GetExecutingAssembly().DefinedTypes;
            // 通常のコントローラクラスを収集する
            _controllers = definedTypes
                .Where(ti => ti.BaseType == typeof(ControllerBase))
                .Where(ti => ti.CustomAttributes.Any(a => a.AttributeType == typeof(ControllerAttribute)))
                .Select(ti => ti.UnderlyingSystemType)
                .ToDictionary(t => t.GetCustomAttribute<ControllerAttribute>().ResourceName.ToLower());
            // エラーコントローラクラスを収集する
            _errorControllers = definedTypes
                .Where(ti => ti.BaseType == typeof(ErrorController))
                .Where(ti => ti.CustomAttributes.Any(a => a.AttributeType == typeof(ErrorControllerAttribute)))
                .Select(ti => ti.UnderlyingSystemType)
                .ToDictionary(t => t.GetCustomAttribute<ErrorControllerAttribute>().StatusCode);
        }

        /// <summary>コントローラを生成する</summary>
        /// <param name="resourceName">リソース名</param>
        /// <returns>コントローラクラス</returns>
        public ControllerBase CreateController(string resourceName)
            => _controllers.ContainsKey(resourceName.ToLower())
                ? (ControllerBase)Activator.CreateInstance(_controllers[resourceName.ToLower()])
                : null;

        /// <summary>エラーコントローラを作成する</summary>
        /// <param name="statusCode"></param>
        /// <returns>コントローラクラス</returns>
        public ErrorController CreateErrorController(HttpStatusCode statusCode)
            => _errorControllers.ContainsKey(statusCode)
                ? (ErrorController)Activator.CreateInstance(_errorControllers[statusCode])
                : null;
    }
}