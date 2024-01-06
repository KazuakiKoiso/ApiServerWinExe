using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tools.ListView;

namespace ApiServerWinExe
{
    public partial class FrmMain : Form
    {
        private MonitorChanged<bool> _powerOn = new MonitorChanged<bool>(false);
        private ApiServer _server = new ApiServer();
        private FrmUserDb _frmUserDb;
        private ListItemSorter _sorter;

        /// <summary>コンストラクタ</summary>
        public FrmMain()
        {
            InitializeComponent();
            _powerOn.OnChanged += _powerOn_OnChanged;
            _server.PrettyResponse = chkPretty.Checked;
            _server.OnRequested += _server_OnRequested;
            _server.OnResponsed += _server_OnResponsed;

            clmId.Tag = nameof(ApiLog.Id);
            clmIp.Tag = nameof(ApiLog.Ip);
            clmDirection.Tag = (Func<ApiLog, string>)(
                log => log.Direction == Direction.Received ? "→" : "←");
            clmMethod.Tag = nameof(ApiLog.Method);
            clmResource.Tag = nameof(ApiLog.Resource);
            clmBody.Tag = nameof(ApiLog.Body);

            _sorter = new ListItemSorter(lvLog);
        }

        /// <summary>画面終了時</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 必ずシャットダウンする
            _powerOn.Value = false;
            _server.Dispose();
        }

        /// <summary>チェック状態に応じて電源を切り替える</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPower_CheckedChanged(object sender, EventArgs e)
        {
            _powerOn.Value = btnPower.Checked;
        }

        /// <summary>ログクリア</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClearLog_Click(object sender, EventArgs e)
        {
            lvLog.Items.Clear();
        }

        /// <summary>ユーザDB表示ボタン</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShowDb_Click(object sender, EventArgs e)
        {
            if(_frmUserDb == null)
            {
                _frmUserDb = new FrmUserDb();
                _frmUserDb.Show(this);
                _frmUserDb.FormClosed += (_s, _e) => _frmUserDb = null;
            }
        }

        /// <summary>電源状態変更</summary>
        /// <param name="before"></param>
        /// <param name="after"></param>
        private void _powerOn_OnChanged(bool before, bool after)
        {
            btnPower.Text = after ? "受信中" : "停止中";
            btnPower.BackColor = after ? Color.Lime : Color.Red;

            txtAddress.Enabled = before;
            numPort.Enabled = before;
            if (after)
            {
                _server.StartListen(txtAddress.Text.Trim(), (int)numPort.Value);
            }
            else
            {
                _server.StopListen();
            }
        }

        /// <summary>PrettyResponseのチェック状態変化</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkPretty_CheckedChanged(object sender, EventArgs e)
        {
            _server.PrettyResponse = chkPretty.Checked;
        }

        /// <summary>受信イベント</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _server_OnRequested(object sender, ApiServer.ServerEventArgs e)
        {
            AutoInvoke(() =>
            {
                // Prettyの場合でもログ出力用に強制的にPretty解除する
                var notPrettyObject = JsonConvert.DeserializeObject(e.Body);
                string notPrettyJson = JsonConvert.SerializeObject(notPrettyObject);
                ApiLog log = new ApiLog()
                {
                    Id = lvLog.ItemsEx<ApiLog>().Count() + 1,
                    Ip = e.Ip,
                    Timestamp = DateTime.Now,
                    Direction = Direction.Received,
                    Method = e.Method,
                    Headers = e.Headers,
                    Resource = e.Url,
                    Body = notPrettyJson,
                };
                lvLog.Items.Add(lvLog.NewItem(log));
                //自動スクロール
                LvLog_AutoScroll();
            });
        }

        /// <summary>応答イベント</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _server_OnResponsed(object sender, ApiServer.ServerEventArgs e)
        {
            AutoInvoke(() =>
            {
                // Prettyの場合でもログ出力用に強制的にPretty解除する
                var notPrettyObject = JsonConvert.DeserializeObject(e.Body);
                string notPrettyJson = JsonConvert.SerializeObject(notPrettyObject);
                ApiLog log = new ApiLog()
                {
                    Id = lvLog.ItemsEx<ApiLog>().Count() + 1,
                    Ip= e.Ip,
                    Timestamp = DateTime.Now,
                    Direction = Direction.Responsed,
                    Method = e.Method,
                    Headers = e.Headers,
                    Resource = e.Url,
                    Body = notPrettyJson,
                };

                lvLog.Items.Add(lvLog.NewItem(log));
                //自動スクロール
                LvLog_AutoScroll();
            });
        }

        /// <summary>スレッドセーフのためにInvokeを自動判断する</summary>
        /// <param name="action">処理</param>
        private void AutoInvoke(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        /// <summary>ログのダブルクリック</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LvLog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ApiLog log = lvLog.SelectedItemsEx<ApiLog>().First().Data;
            FrmLogDetail frmLogDetail = new FrmLogDetail(log);
            frmLogDetail.ShowDialog(this);
        }
        /// <summary>リストビューの自動スクロール</summary>
        private void LvLog_AutoScroll()
        {
            if (chkScroll.Checked)
            {
                lvLog.SelectedIndices.Clear();
                lvLog.Items[lvLog.Items.Count - 1].Selected = true;
                lvLog.EnsureVisible(lvLog.Items.Count - 1);
                lvLog.Focus();
            }
        }
    }
}
