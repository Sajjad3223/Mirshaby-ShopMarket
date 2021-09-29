namespace ShopMarket.Core.Utilities
{
    public class PriceCalculator
    {
        public static int CalculateDiscountPrice(int price, float? discount)
        {
            if (discount == null) discount = 0;
            return (int)(price -
                    ((price * discount.Value) / 100));
        }
    }
}