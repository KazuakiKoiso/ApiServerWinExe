using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace Tools.ListView
{
    /// <summary>ListViewItemに様々な機能を追加したクラス</summary>
    public class ListViewItemEx<T> : ListViewItem
        where T : class
    {
        /// <summary>データ</summary>
        public T Data { get; private set; } = null;

        /// <summary>ColumnsのTagに設定されたプロパティ名を基に項目を生成する</summary>
        /// <param name="data">ListViewItem.Tagに関連づくデータ</param>
        /// <param name="columns">Columns</param>
        /// <returns>生成された項目</returns>
        public static ListViewItemEx<T> FromColumns(T data, System.Windows.Forms.ListView.ColumnHeaderCollection columns)
        {
            Type t = typeof(T);
            Dictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>();
            List<string> lst = new List<string>();
            foreach (ColumnHeader c in columns)
            {
                string value = string.Empty;

                if (c.Tag is Func<T, string> fnc)
                {
                    value = fnc(data);
                }
                else if (!string.IsNullOrEmpty(c.Tag?.ToString()))
                {
                    string propName = c.Tag.ToString();
                    if (!properties.ContainsKey(propName))
                    {
                        properties[propName] = t.GetProperty(propName);
                    }
                    value = properties[propName].GetValue(data)?.ToString();
                }
                lst.Add(value);
            }

            ListViewItemEx<T> result = new ListViewItemEx<T>(lst.ToArray());
            result.Data = data;

            return result;
        }

        #region コンストラクタ
        // 親クラスであるListViewItemのコンストラクタを
        // とりあえず全てラッピングしたが不要だったかも
        public ListViewItemEx() : base() { }
        public ListViewItemEx(ListViewGroup group) : base(group) { }
        public ListViewItemEx(string text) : base(text) { }
        public ListViewItemEx(string[] items) : base(items) { }
        public ListViewItemEx(ListViewSubItem[] subItems, int imageIndex) : base(subItems, imageIndex) { }
        public ListViewItemEx(ListViewSubItem[] subItems, string imageKey) : base(subItems, imageKey) { }
        public ListViewItemEx(string text, int imageIndex) : base(text, imageIndex) { }
        public ListViewItemEx(string text, ListViewGroup group) : base(text, group) { }
        public ListViewItemEx(string text, string imageKey) : base(text, imageKey) { }
        public ListViewItemEx(string[] items, int imageIndex) : base(items, imageIndex) { }
        public ListViewItemEx(string[] items, ListViewGroup group) : base(items, group) { }
        public ListViewItemEx(string[] items, string imageKey) : base(items, imageKey) { }
        public ListViewItemEx(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        public ListViewItemEx(ListViewSubItem[] items, int imageIndex, ListViewGroup group) : base(items, imageIndex, group) { }
        public ListViewItemEx(ListViewSubItem[] items, string imageKey, ListViewGroup group) : base(items, imageKey, group) { }
        public ListViewItemEx(string text, int imageIndex, ListViewGroup group) : base(text, imageIndex, group) { }
        public ListViewItemEx(string text, string imageKey, ListViewGroup group) : base(text, imageKey, group) { }
        public ListViewItemEx(string[] items, int imageIndex, ListViewGroup group) : base(items, imageIndex, group) { }
        public ListViewItemEx(string[] items, string imageKey, ListViewGroup group) : base(items, imageKey, group) { }
        public ListViewItemEx(string[] items, int imageIndex, System.Drawing.Color foreColor, System.Drawing.Color backColor, System.Drawing.Font font) : base(items, imageIndex, foreColor, backColor, font) { }
        public ListViewItemEx(string[] items, int imageIndex, System.Drawing.Color foreColor, System.Drawing.Color backColor, System.Drawing.Font font, ListViewGroup group) : base(items, imageIndex, foreColor, backColor, font, group) { }
        public ListViewItemEx(string[] items, string imageKey, System.Drawing.Color foreColor, System.Drawing.Color backColor, System.Drawing.Font font, ListViewGroup group) : base(items, imageKey, foreColor, backColor, font, group) { }
        #endregion

        /// <summary>現在の列に応じてテキストを再設定する</summary>
        public void ReLayoutText()
        {
            if (ListView.Columns.Count < SubItems.Count)
            {
                // 列数がサブアイテム数より少ない場合は列数に合わせてサブアイテムを削除する
                int diff = SubItems.Count - ListView.Columns.Count;
                for (int i = 0; i < diff; i++)
                {
                    SubItems.RemoveAt(SubItems.Count - 1);
                }
            }
            else if (ListView.Columns.Count > SubItems.Count)
            {
                // 列数がサブアイテム数より多い場合は列数に合わせてサブアイテムを追加する
                int diff = ListView.Columns.Count - SubItems.Count;
                for (int i = 0; i < diff; i++)
                {
                    SubItems.Add("");
                }
            }

            Type t = typeof(T);
            Dictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>();
            foreach (ColumnHeader c in ListView.Columns)
            {
                string value = string.Empty;
                if (c.Tag is Func<T, string> fnc)
                {
                    value = fnc(Data);
                }
                else if (!string.IsNullOrEmpty(c.Tag?.ToString()))
                {
                    string propName = c.Tag.ToString();
                    if (!properties.ContainsKey(propName))
                    {
                        properties[propName] = t.GetProperty(propName);
                    }
                    value = properties[propName].GetValue(Data).ToString();
                }
                SubItems[c.Index].Text = value;
            }
        }
    }
}
