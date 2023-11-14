namespace _0_Framework.Application
{
    public static class PersianUtils
    {
        public static string PersianizePrice(this double price)
        {
            // Convert the decimal price to a string
            string priceStr = price.ToString();

            // Use your logic to replace digits with Persian digits
            // For simplicity, this example just replaces 0-9 with the corresponding Persian digits
            string persianizedPrice = priceStr
                .Replace("0", "۰")
                .Replace("1", "۱")
                .Replace("2", "۲")
                .Replace("3", "۳")
                .Replace("4", "۴")
                .Replace("5", "۵")
                .Replace("6", "۶")
                .Replace("7", "۷")
                .Replace("8", "۸")
                .Replace("9", "۹");

            return persianizedPrice;
        }
    }
}
