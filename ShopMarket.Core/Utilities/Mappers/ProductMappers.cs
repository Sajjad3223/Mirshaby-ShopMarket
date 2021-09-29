using ShopMarket.Core.ViewModels.ShopViewModels;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.Utilities.Mappers
{
    public static class ProductMappers
    {
        public static ProductViewModel MapToViewModel(this Product product)
        {
            return new ProductViewModel()
            {
                ProductId = product.Id,
                Title = product.Title,
                Description = product.Description,
                Discount = product.Discount,
                Price = product.Price,
                Score = product.Score,
                CategoryId = product.CategoryId,
                StoreId = product.StoreId,
                CreationDate = product.CreationDate,
                Tags = product.Tags,
                Visit = product.Visit,
                Remaining = product.Remaining,
                DiscountCount = product.DiscountCount,
                ShowInSlider = product.ShowInSlider,
                ShortLink = product.ShortLink
            };
        }

        public static Product MapToProduct(this ProductViewModel product)
        {
            return new Product()
            {
                Id = product.ProductId,
                Title = product.Title,
                Description = product.Description,
                Discount = product.Discount,
                Price = product.Price,
                Score = product.Score,
                CategoryId = product.CategoryId,
                StoreId = product.StoreId,
                Tags = product.Tags,
                Visit = product.Visit,
                Remaining = product.Remaining,
                DiscountCount = product.DiscountCount,
                ShowInSlider = product.ShowInSlider,
                ShortLink = product.ShortLink
            };
        }
        
        public static LikedProductViewModel MapToViewModel(this LikedProduct like)
        {
            int price = (int)((like.Product.Discount.HasValue)
                ? ((like.Product.Price * like.Product.Discount.Value) / 100)
                : like.Product.Price);

            return new LikedProductViewModel()
            {
                Title = like.Product.Title,
                Price = price,
                ProductId = like.ProductId,
                LikedId = like.LikedProductId,
                Score = like.Product.Score
            };
        }

        public static ProductCommentViewModel MapToViewModel(this ProductComment comment)
        {
            return new ProductCommentViewModel()
            {
                UserId = comment.UserId,
                ProductId = comment.ProductId,
                CommentId = comment.Id,
                Text = comment.Text,
                Score = comment.Score,
                CreationDate = comment.CreationDate
            };
        }

        public static ProductComment MapToProductComment(this ProductCommentViewModel comment)
        {
            return new ProductComment()
            {
                UserId = comment.UserId,
                ProductId = comment.ProductId,
                Id = comment.CommentId,
                Text = comment.Text,
                Score = comment.Score,
                CreationDate = comment.CreationDate
            };
        }

        public static ShopCategoryViewModel MapToViewModel(this ShopCategory category)
        {
            return new ShopCategoryViewModel()
            {
                CategoryId = category.Id,
                ParentId = category.ParentId,
                Title = category.Title,
                CategoryImage = category.CategoryImage,
                ShowInMainPage = category.ShowInMainPage,
                CreationDate = category.CreationDate
            };
        }

        public static ShopCategory MapToShopCategory(this ShopCategoryViewModel categoryVm)
        {
            return new ShopCategory()
            {
                Id = categoryVm.CategoryId,
                ParentId = categoryVm.ParentId,
                Title = categoryVm.Title,
                CategoryImage = categoryVm.CategoryImage,
                ShowInMainPage = categoryVm.ShowInMainPage,
                Slug = categoryVm.Slug
            };
        }




    }
}