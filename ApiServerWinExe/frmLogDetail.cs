using Newtonsoft.Json;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tools.ListView;

namespace ApiServerWinExe
{
    /// <summary>ログ詳細画面</summary>
    public partial class frmLogDetail : Form
    {
        /// <summary>リストビューソート</summary>
        private ListItemSorter _sorter;

        /// <summary>コンストラクタ</summary>
        /// <param name="log">ログ</sparam>
        public frmLogDetail(ApiLog log)
        {
            InitializeComponent();

            lblId.Text = $"ログID：{log.Id}";
            lblTimestamp.Text = $"日時：{log.Timestamp.ToString("yyyy/MM/dd HH:mm:ss")}";
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
