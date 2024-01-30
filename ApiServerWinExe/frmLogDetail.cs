using System.Data;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Tools.ListView;

namespace ApiServerWinExe
{
    /// <summary>ログ詳細画面</summary>
    public partial class FrmLogDetail : Form
    {
#pragma warning disable IDE0052
        /// <summary>リストビューソート</summary>
        private readonly ListItemSorter _sorter;
#pragma warning restore IDE0052

        /// <summary>コンストラクタ</summary>
        /// <param name="log">ログ</sparam>
        public FrmLogDetail(ApiLog log)
        {
            InitializeComponent();

            lblId.Text = $"ログID：{log.Id}";
            lblTimestamp.Text = $"日時：{log.Timestamp:yyyy/MM/dd HH:mm:ss}";
            lblDirection.Text = $"方向：{(log.Direction == Direction.Received ? "受信" : "返信")}";
            lblMethod.Text = $"HTTPメソッド：{log.Method}";
            lblResource.Text = $"対象リソース：{log.Resource}";
            lblIp.Text = $"IP : {log.Ip}";

            _sorter = new ListItemSorter(lvHeader);
            var items = log.Headers.AllKeys
                            .Select(k => new { Name = k, Value = log.Headers[k] });
            lvHeader.Items.AddRange(lvHeader.NewItem(items).ToArray());

            var obj = JsonConvert.DeserializeObject(log.Body);
            txtBody.Text = JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
