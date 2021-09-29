namespace ShopMarket.Core.Utilities
{
    public class Directories
    {
        public const string DOMAIN = "https://mirshaby-shopmarket.ir/";

        public const string ProductImage = "wwwroot/images/products";
        public static string GetProductImage(string imageName,int productId) => $"{ProductImage.Replace("wwwroot", "")}/{productId}/{imageName}";

        public const string UserImage = "wwwroot/images/users";
        public static string GetUserImage(string imageName) => $"{UserImage.Replace("wwwroot", "")}/{imageName}";

        public const string CategoryImage = "wwwroot/images/categories";
        public static string GetCategoryImage(string imageName) => $"{CategoryImage.Replace("wwwroot", "")}/{imageName}";

        public const string SliderImage = "wwwroot/images/slider";
        public static string GetSlideImage(string imageName) => $"{SliderImage.Replace("wwwroot", "")}/{imageName}";

        public const string BannerImage = "wwwroot/images/banner";
        public static string GetBannerImage(string imageName) => $"{BannerImage.Replace("wwwroot", "")}/{imageName}";
    }
}
