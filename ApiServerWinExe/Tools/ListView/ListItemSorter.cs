using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Tools.ListView
{
    /// <summary>
    /// <para>リストビューのソートを管理するクラス</para>
    /// <para>比較関数は外部で用意するか、staticな比較関数から選択する。</param>
    /// <para>比較関数を独自に定義する場合は以下の通りに戻り値を制御すること</param>
    /// <para>・x＜y →負の値</param>
    /// <para>・x＝0 →0</param>
    /// <para>・x＞y →正の値</param>
    /// </summary>
    public class ListItemSorter : IComparer
    {
        #region Win32API定義
#pragma warning disable IDE0051
        [StructLayout(LayoutKind.Sequential)]
        private struct HDITEM
        {
            public Int32 mask;
            public Int32 cxy;
            [MarshalAs(UnmanagedType.LPTStr)]
            public String pszText;
            public IntPtr hbm;
            public Int32 cchTextMax;
            public Int32 fmt;
            public Int32 lParam;
            public Int32 iImage;
            public Int32 iOrder;
        };

        // Parameters for ListView-Headers
        private const Int32 HDI_FORMAT = 0x0004;
        private const Int32 HDF_LEFT = 0x0000;
        private const Int32 HDF_STRING = 0x4000;
        private const Int32 HDF_SORTUP = 0x0400;
        private const Int32 HDF_SORTDOWN = 0x0200;
        private const Int32 LVM_GETHEADER = 0x1000 + 31;  // LVM_FIRST + 31
        private const Int32 HDM_GETITEM = 0x1200 + 11;  // HDM_FIRST + 11
        private const Int32 HDM_SETITEM = 0x1200 + 12;  // HDM_FIRST + 12
#pragma warning restore IDE0051

        /// <summary>ウィンドウメッセージ送信</summary>
        /// <param name="Handle">ウィンドウハンドル</param>
        /// <param name="msg">ウィンドウメッセージ</param>
        /// <param name="wParam">パラメータ１</param>
        /// <param name="lParam">パラメータ２</param>
        /// <returns>メッセージ処理結果</returns>
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessageITEM(IntPtr Handle, Int32 msg, IntPtr wParam, ref HDITEM lParam);
        /// <summary>ウィンドウメッセージ送信</summary>
        /// <param name="Handle">ウィンドウハンドル</param>
        /// <param name="msg">ウィンドウメッセージ</param>
        /// <param name="wParam">パラメータ１</param>
        /// <param name="lParam">パラメータ２</param>
        /// <returns>メッセージ処理結果</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);
        #endregion

        /// <summary>前回までソートしていた列</summary>
        private int PrevColumn = 0;
        /// <summary>現在ソートしている列</summary>
        private int _Column = -1;
        /// <summary>ソート管理対象のリストビュー</summary>
        private readonly System.Windows.Forms.ListView Target = null;

        /// <summary>現在ソートしている列</summary>
        public int Column
        {
            get { return _Column; }
            set
            {
                PrevColumn = _Column;
                _Column = value;
                Ascending = PrevColumn != Column || !Ascending;
            }
        }
        /// <summary>昇順/降順</summary>
        public bool Ascending { get; private set; } = true;

        /// <summary>列インデックス毎の比較関数。ここに登録されていない場合は文字列で比較する</summary>
        public Dictionary<int, Func<int, ListViewItem, ListViewItem, int>> Comparer { get; set; } = new Dictionary<int, Func<int, ListViewItem, ListViewItem, int>>();

        /// <summary>コンストラクタ</summary>
        /// <param name="listView">リストビュー</param>
        public ListItemSorter(System.Windows.Forms.ListView listView)
        {
            Target = listView;
            Target.ColumnClick += Target_ColumnClick;
        }

        /// <summary>リストビューの列クリックイベント</summary>
        /// <param name="sender">リストビュー</param>
        /// <param name="e">イベント情報</param>
        private void Target_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sort(e.Column);
        }

        /// <summary>ソート実行</summary>
        /// <param name="colIdx">ソート対象列インデックス</param>
        /// <param name="asc">昇順/降順</param>
        public void Sort(int colIdx, bool? asc = null)
        {
            Column = colIdx;
            if(asc.HasValue)
            {
                Ascending = asc.Value;
            }
            if (Target.ListViewItemSorter == null)
            {
                // 値を設定すると自動的にソートされる
                Target.ListViewItemSorter = this;
            }
            else
            {
                Target.Sort();
            }
            // 列にソートマークを設定
            foreach (ColumnHeader col in Target.Columns)
            {
                SetMark(col.Index, Column == col.Index ? Ascending ? SortOrder.Ascending : SortOrder.Descending
                                                       : SortOrder.None);
            }
        }

        /// <summary>IComparerインターフェースの比較関数</summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>-1:x＜y 0:x＝y 1:x＞y</returns>
        public int Compare(object x, object y)
        {
            // 比較
            var itemX = x as ListViewItem;
            var itemY = y as ListViewItem;
            var result = Comparer.ContainsKey(Column) ? Comparer[Column](Column, itemX, itemY) : CompareString(Column, itemX, itemY);

            // 昇順/降順
            result *= Ascending ? 1 : -1;

            return result;
        }

        /// <summary>値を文字列として比較する</summary>
        /// <param name="idx">インデックス</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>比較結果</returns>
        public static int CompareString(int idx, object x, object y)
        {
            var itemX = x as ListViewItem;
            var itemY = y as ListViewItem;
            return string.Compare(itemX.SubItems[idx].Text, itemY.SubItems[idx].Text);
        }

        /// <summary>値を数値として比較する</summary>
        /// <param name="idx">インデックス</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>比較結果</returns>
        public static int CompareInt(int idx, object x, object y)
        {
            var itemX = x as ListViewItem;
            var itemY = y as ListViewItem;
            var intX = int.Parse(itemX.SubItems[idx].Text);
            var intY = int.Parse(itemY.SubItems[idx].Text);
            return intX - intY;
        }

        /// <summary>値を日付として比較する</summary>
        /// <param name="idx">インデックス</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>比較結果</returns>
        public static int CompareDate(int idx, object x, object y)
        {
            var itemX = x as ListViewItem;
            var itemY = y as ListViewItem;
            var timeX = DateTime.Parse(itemX.SubItems[idx].Text);
            var timeY = DateTime.Parse(itemY.SubItems[idx].Text);

            return DateTime.Compare(timeX, timeY);
        }

        /// <summary>リストビューの列に△マークを設定する</summary>
        /// <param name="idx">列インデックス</param>
        /// <param name="order">ソート設定</param>
        private void SetMark(int idx, SortOrder order)
        {
            var hColHeader = SendMessage(Target.Handle, LVM_GETHEADER, 0, 0);
            var hdItem = new HDITEM();
            var colHeader = new IntPtr(idx);

            hdItem.mask = HDI_FORMAT;
            SendMessageITEM(hColHeader, HDM_GETITEM, colHeader, ref hdItem);

            if (order == SortOrder.Ascending)
            {
                hdItem.fmt &= ~HDF_SORTDOWN;
                hdItem.fmt |= HDF_SORTUP;
            }
            else if (order == SortOrder.Descending)
            {
                hdItem.fmt &= ~HDF_SORTUP;
                hdItem.fmt |= HDF_SORTDOWN;
            }
            else if (order == SortOrder.None)
            {
                hdItem.fmt &= ~HDF_SORTDOWN & ~HDF_SORTUP;
            }

            SendMessageITEM(hColHeader, HDM_SETITEM, colHeader, ref hdItem);
        }
    }
}
