using ShopMarket.Core.Utilities;

namespace ShopMarket.Core.ViewModels.UserViewModels
{
    public class RecentVisitViewModel
    {
        public int RecentVisitId { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public string Title { get; set; }

        public string Slug => Title.ToSlug();

        public string MainImageName { get; set; }

        public int Score { get; set; }

        public int Price { get; set; }
    }
}