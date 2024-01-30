namespace ApiServerWinExe.Extensions
{
    /// <summary>文字列の拡張メソッド</summary>
    public static class StringExtension
    {
        /// <summary>指定文字より後ろを取得する</summary>
        /// <param name="this">対象</param>
        /// <param name="target">検索文字列</param>
        /// <returns>検索文字列以降</returns>
        public static string Over(this string @this, string target)
        {
            var index = @this.IndexOf(target);
            return (index >= 0) ? @this.Substring(index + target.Length) : string.Empty;
        }

        /// <summary>検索文字列の手前までを取得する</summary>
        /// <param name="this">対象</param>
        /// <param name="target">検索文字列</param>
        /// <returns>検索文字列以前</returns>
        public static string Until(this string @this, string target)
        {
            var index = @this.IndexOf(target);
            return (index >= 0) ? @this.Substring(0, index) : @this;
        }

        /// <summary>文字列が数値か判断する</summary>
        /// <param name="this">文字列</param>
        /// <returns>数値か否か</returns>
        public static bool IsNumeric(this string @this)
            => int.TryParse(@this, out _);

        /// <summary>文字列を数値に変換する</summary>
        /// <param name="this">文字列</param>
        /// <returns>数値</returns>
        public static int ToInt(this string @this)
            => int.Parse(@this);
    }
}
