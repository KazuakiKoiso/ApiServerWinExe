using System;
using System.Net;
using System.Threading.Tasks;

namespace ApiServerWinExe
{
    /// <summary>
    /// http://+80/Temporary_Listen_Addresses専用のリスナー
    /// </summary>
    public class LocalHttpListener : IDisposable
    {
        /// <summary>受信イベント用のデリゲート定義</summary>
        /// <param name="request">リクエスト</param>
        /// <param name="response">レスポンス</param>
        public delegate Task OnReceivedHandler(HttpListenerRequest request, HttpListenerResponse response);

        /// <summary>HttpListener本体</summary>
        private HttpListener _listener;

        /// <summary>受信イベント</summary>
        public event OnReceivedHandler OnReceived;

        /// <summary>コンストラクタ</summary>
        public LocalHttpListener()
        {
        }

        /// <summary>Listen開始</summary>
        public void StartListen()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Clear();

            // ↓のようにするには管理者権限が必要となる
            // _listener.Prefixes.Add($"http://*:{port}/");

            // こうすると管理者権限がなくてもHttpListenerでListenできるらしい
            // WCFによるプロセス間HTTP通信のために特別なURLが用意されているのだとか
            _listener.Prefixes.Add($"http://+:80/Temporary_Listen_Addresses/");

            _listener.Start();
            _listener.BeginGetContext(new AsyncCallback(OnContext), _listener);
        }

        /// <summary>Listen停止</summary>
        public void StopListen()
        {
            if (_listener?.IsListening ?? false)
            {
                _listener?.Stop();
            }
            _listener?.Close();
        }

        /// <summary>リクエスト受信</summary>
        /// <param name="ir"></param>
        protected async void OnContext(IAsyncResult ir)
        {
            try
            {
                var listener = ir.AsyncState as HttpListener;
                if (listener.IsListening)
                {
                    var context = listener.EndGetContext(ir);
                    // ただちに次の受付を開始する
                    listener.BeginGetContext(OnContext, listener);

                    var req = context.Request;
                    using (var res = context.Response)
                    {
                        if (OnReceived != null)
                        {
                            await OnReceived.Invoke(req, res);
                        }
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                // HttpListenerをClose()するときに必ずOnContextが発生する模様
                // Close済みのListenerに対してEndGetContext()すると例外が発生するが
                // OnContextを発生させないかClose済みを確認する方法が不明なためcatchする
            }
        }

        /// <summary>開放</summary>
        public void Dispose()
        {
            StopListen();
        }
    }
}
