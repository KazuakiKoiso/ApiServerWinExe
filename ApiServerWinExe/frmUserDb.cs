using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ApiServerWinExe.Users;
using Tools.ListView;

namespace ApiServerWinExe
{
    /// <summary>ユーザ情報DBの内容を表示する画面</summary>
    public partial class FrmUserDb : Form
    {
#pragma warning disable IDE0052
        /// <summary>リストビューソート</summary>
        private readonly ListItemSorter _sorter = null;
#pragma warning restore IDE0052

        /// <summary>コンストラクタ</summary>
        public FrmUserDb()
        {
            InitializeComponent();
            _sorter = new ListItemSorter(lvDb);
            UpdateList();
            UserRepository.Instance.UserAdded += Instance_UserAdded;
            UserRepository.Instance.UserUpdated += Instance_UserUpdated;
            UserRepository.Instance.UserDeleted += Instance_UserDeleted;
        }

        /// <summary>DBのユーザ情報が削除された時、自動で画面を更新</summary>
        /// <param name="sender"></param>
        /// <param name="e">削除されたユーザID</param>
        private void Instance_UserDeleted(object sender, int e)
        {
            AutoInvoke(() =>
            {
                UpdateList();
            });
        }

        /// <summary>DBのユーザ情報が更新された時、自動で画面を更新</summary>
        /// <param name="sender"></param>
        /// <param name="e">ユーザ情報</param>
        private void Instance_UserUpdated(object sender, UserData e)
        {
            AutoInvoke(() =>
            {
                UpdateList();
            });
        }

        /// <summary>DBのユーザ情報が追加された時、自動で画面を更新</summary>
        /// <param name="sender"></param>
        /// <param name="e">ユーザ情報</param>
        private void Instance_UserAdded(object sender, UserData e)
        {
            AutoInvoke(() =>
            {
                //1行付け足すコード
                lvDb.Items.Add(lvDb.NewItem(e));
            });
        }

        /// <summary>表示更新</summary>
        private void UpdateList()
        {
            lvDb.Items.Clear();
            IEnumerable<UserData> users = UserRepository.Instance.GetUsers();
            lvDb.Items.AddRange(lvDb.NewItem(users).ToArray());
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

        /// <summary>画面終了処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmUserDb_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserRepository.Instance.UserAdded -= Instance_UserAdded;
            UserRepository.Instance.UserUpdated -= Instance_UserUpdated;
            UserRepository.Instance.UserDeleted -= Instance_UserDeleted;
        }
    }
}
