using System;
using System.Windows.Forms;

namespace ApiServerWinExe
{
    /// <summary>プログラム本体</summary>
    static class Program
    {
        /// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
