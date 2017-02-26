namespace SimpleMVC.Extensions
{
    public static class StringExtentions
    {
        public static string ToUpperFirst(this string str)
        {
            return char.ToUpper(c: str[index: 0]) + str.Substring(startIndex: 1);
        }
    }
}