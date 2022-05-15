namespace ApiServerWinExe.Extensions
{
    public static class StringExtension
    {
        public static string Over(this string @this, string target)
        {
            int index = @this.IndexOf(target);
            return (index >= 0) ? @this.Substring(index + target.Length) : string.Empty;
        }

        public static string Until(this string @this, string target)
        {
            int index = @this.IndexOf(target);
            return (index >= 0) ? @this.Substring(0, index) : @this;
        }

        public static bool IsNumeric(this string @this)
            => int.TryParse(@this, out int value);

        public static int ToInt(this string @this)
            => int.Parse(@this);
    }
}
