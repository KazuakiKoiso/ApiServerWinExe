using ApiServerWinExe.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tools.ListView;

namespace ApiServerWinExe
{
    /// <summary>ユーザ情報DBの内容を表示する画面</summary>
    public partial class FrmUserDb : Form
    {
        /// <summary>リストビューソート</summary>
        private ListItemSorter _sorter = null;

        /// <summary>コンストラクタ</summary>
        public FrmUserDb()
        {
            InitializeComponent();
            _sorter = new ListItemSorter(lvDb);
            UpdateList();
        }

        /// <summary>更新ボタン</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        /// <summary>表示更新</summary>
        private void UpdateList()
        {
            lvDb.Items.Clear();
            IEnumerable<UserData> users = UserRepository.Instance.GetUsers();
            lvDb.Items.AddRange(lvDb.NewItem(users).ToArray());
        }
    }
}
