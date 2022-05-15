using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tools.ListView
{
    /// <summary>リストビューに対する拡張メソッド</summary>
    public static class ListViewExtension
    {
        /// <summary>ListViewItemExのリストを取得</summary>
        /// <typeparam name="T">データ型</typeparam>
        /// <param name="this">リストビュー</param>
        /// <returns></returns>
        public static IEnumerable<ListViewItemEx<T>> ItemsEx<T>(this System.Windows.Forms.ListView @this)
            where T : class
        {
            return @this.Items.OfType<ListViewItemEx<T>>();
        }

        /// <summary>ListViewItemのリスト化を簡略化</summary>
        /// <param name="this">ListViewItem</param>
        /// <returns>List</returns>
        public static List<ListViewItem> ToList(this System.Windows.Forms.ListView.ListViewItemCollection @this)
        {
            return @this.OfType<ListViewItem>().ToList();
        }

        /// <summary>選択されたListViewItemExのリストを取得</summary>
        /// <typeparam name="T">データ型</typeparam>
        /// <param name="this">リストビュー</param>
        /// <returns></returns>
        public static IEnumerable<ListViewItemEx<T>> SelectedItemsEx<T>(this System.Windows.Forms.ListView @this)
            where T : class
        {
            return @this.SelectedItems.OfType<ListViewItemEx<T>>();
        }

        /// <summary>ListViewItemのリスト化を簡略化</summary>
        /// <param name="this">SelectedListViewItem</param>
        /// <returns>List</returns>
        public static List<ListViewItem> ToList(this System.Windows.Forms.ListView.SelectedListViewItemCollection @this)
        {
            return @this.OfType<ListViewItem>().ToList();
        }

        /// <summary>チェックされたListViewItemExのリストを取得</summary>
        /// <typeparam name="T">データ型</typeparam>
        /// <param name="this">リストビュー</param>
        /// <returns></returns>
        public static IEnumerable<ListViewItemEx<T>> CheckedItemsEx<T>(this System.Windows.Forms.ListView @this)
            where T : class
        {
            return @this.CheckedItems.OfType<ListViewItemEx<T>>();
        }

        /// <summary>ListViewItemのリスト化を簡略化</summary>
        /// <param name="this">CheckedListViewItem</param>
        /// <returns>List</returns>
        public static List<ListViewItem> ToList(this System.Windows.Forms.ListView.CheckedListViewItemCollection @this)
        {
            return @this.OfType<ListViewItem>().ToList();
        }

        /// <summary>
        /// <para>ListViewの各列に設定されたTag値を元にListViewItemを生成する</para>
        /// <para>このメソッドを使用する場合は予め各列のTagにdataのプロパティ名を設定しておくこと</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="@this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ListViewItemEx<T> NewItem<T>(this System.Windows.Forms.ListView @this, T data)
            where T : class
        {
            return ListViewItemEx<T>.FromColumns(data, @this.Columns);
        }

        /// <summary>
        /// <para>ListViewの各列に設定されたTag値を元にListViewItemを生成する</para>
        /// <para>このメソッドを使用する場合は予め各列のTagにdataのプロパティ名を設定しておくこと</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="@this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IEnumerable<ListViewItemEx<T>> NewItem<T>(this System.Windows.Forms.ListView @this,IEnumerable<T> data)
            where T : class
        {
            return data.Select(d => @this.NewItem(d));
        }

        /// <summary>ListViewItemExに関連付けられたデータのリストを取得</summary>
        /// <typeparam name="T">データ型</typeparam>
        /// <param name="this">Items</param>
        /// <returns>リスト</returns>
        public static IEnumerable<T> Data<T>(this System.Windows.Forms.ListView.ListViewItemCollection @this)
            where T : class
        {
            return @this.OfType<ListViewItemEx<T>>().Select(i => i.Data);
        }

        /// <summary>ListViewItemExに関連付けられたデータのリストを取得</summary>
        /// <typeparam name="T">データ型</typeparam>
        /// <param name="this">Items</param>
        /// <returns>リスト</returns>
        public static IEnumerable<T> Data<T>(this System.Windows.Forms.ListView.SelectedListViewItemCollection @this)
            where T : class
        {
            return @this.OfType<ListViewItemEx<T>>().Select(i => i.Data);
        }

        /// <summary>ListViewItemExに関連付けられたデータのリストを取得</summary>
        /// <typeparam name="T">データ型</typeparam>
        /// <param name="this">Items</param>
        /// <returns>リスト</returns>
        public static IEnumerable<T> Data<T>(this System.Windows.Forms.ListView.CheckedListViewItemCollection @this)
            where T : class
        {
            return @this.OfType<ListViewItemEx<T>>().Select(i => i.Data);
        }
    }
}
