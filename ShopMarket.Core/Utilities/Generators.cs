using System;

namespace ShopMarket.Core.Utilities
{
    public static class Generators
    {
        public static string GetRandomCode(int length = 32)
        {
            length = Math.Clamp(length,5, 32);
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);
        }
    }
}