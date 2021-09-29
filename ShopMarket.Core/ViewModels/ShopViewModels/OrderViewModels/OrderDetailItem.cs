using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Core.ViewModels.ShopViewModels.OrderViewModels
{
    public class OrderDetailItem
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public EColor? Color { get; set; }
        public ESize? Size { get; set; }
        public string SellerName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string ImageName { get; set; }
    }
}