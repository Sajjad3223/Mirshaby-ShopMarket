namespace ShopMarket.Core.Utilities
{
    public static class TextHelper
    {


        public static string ToSlug(this string value)
        {
            return value??"".Trim().ToLower()
                .Replace("~","")
                .Replace("@", "")
                .Replace("#", "")
                .Replace("$", "")
                .Replace("%", "")
                .Replace("^", "")
                .Replace("&", "")
                .Replace("*", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("+", "")
                .Replace(" ", "-")
                .Replace(">", "")
                .Replace("<", "")
                .Replace(@"\", "")
                .Replace("/", "");
        }

        public static string FixEmail(this string email)
        {
            return email.Trim().ToLower();
        }


    }
}