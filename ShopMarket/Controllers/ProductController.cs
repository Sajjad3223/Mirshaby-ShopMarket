using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.ShopViewModels;
using ShopMarket.Core.ViewModels.ShopViewModels.OrderViewModels;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Domain.ShopEntities.OrderEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Controllers
{
    public class ProductController : Controller
    {
        #region Services

        private readonly IShopCategoryService _shopCategoryService;

        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        private readonly IProductDetailService _productDetailService;
        private readonly IProductCommentService _productCommentService;
        private readonly ILikedProductService _likedProductService;
        private readonly IRecentVisitService _recentVisitService;

        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;

        private readonly IAvailableProductColorService _availableColorService;
        private readonly IAvailableProductSizeService _availableSizeService;

        #endregion

        #region Inject Services

        public ProductController(IProductService productService, IProductImageService productImageService, IProductDetailService productDetailService, IProductCommentService productCommentService, IAvailableProductColorService availableColorService, IAvailableProductSizeService availableSizeService, IShopCategoryService shopCategoryService, IOrderItemService orderItemService, IOrderService orderService, ILikedProductService likedProductService, IRecentVisitService recentVisitService)
        {
            _productService = productService;
            _productImageService = productImageService;
            _productDetailService = productDetailService;
            _productCommentService = productCommentService;
            _availableColorService = availableColorService;
            _availableSizeService = availableSizeService;
            _shopCategoryService = shopCategoryService;
            _orderItemService = orderItemService;
            _orderService = orderService;
            _likedProductService = likedProductService;
            _recentVisitService = recentVisitService;
        }
        

        #endregion

        [Route("/product/{productId}/{slug?}")]
        public async Task<IActionResult> ShowProduct(int productId,string? slug)
        {
            FullProductViewModel fullProduct = new FullProductViewModel();
            fullProduct.Details = new List<ProductDetail>();
            fullProduct.Images = new List<ProductImage>();
            fullProduct.Colors = new List<AvailableProductColor>();
            fullProduct.Sizes = new List<AvailableProductSize>();

            fullProduct.ProductViewModel = await _productService.GetProduct(productId);
            
            fullProduct.Images = _productImageService.GetAll(productId).ToList();
            fullProduct.Details = _productDetailService.GetProductDetails(productId).ToList();
            fullProduct.Colors = _availableColorService.GetAllAvailableColors(productId).ToList();
            fullProduct.Sizes = _availableSizeService.GetAllAvailableSizes(productId).ToList();

            fullProduct.ProductViewModel.MainImage = (await _productImageService.GetMainImage(productId)).ImageName;

            var category = (await _shopCategoryService.GetCategory(fullProduct.ProductViewModel.CategoryId));
            ViewBag.Category = category;
            if (category.ParentId != null)
                ViewBag.ParentCategory = await _shopCategoryService.GetCategory(category.ParentId.Value);

            await _productService.AddVisitToProduct(productId);

            if (User.Identity.IsAuthenticated)
            {
                _recentVisitService.InsertRecentVisit(new RecentVisit()
                {
                    ProductId = productId,
                    UserId = User.GetUserId()
                });
            }

            return View(fullProduct);
        }

        [Route("/p/{key}")]
        public async Task<IActionResult> ShortKeyRedirect(string key)
        {
            var product = await _productService.GetProductByShortLink(key);
            if (product == null)
                return NotFound();
            return RedirectToAction("ShowProduct", new
            {
                productId = product.ProductId,
                slug = product.Slug
            });
        }

        [Authorize]
        [Route("/product/addtocart/{productId}/{count}/{color?}/{size?}")]
        public async Task<IActionResult> AddToCart(int productId,int count = 1, string? color = "", string? size = "")
        {
            int userId = User.GetUserId();
            OrderViewModel Order;
            var product = await _productService.GetProduct(productId);
            if (product.Remaining <= 0)
                return null;
            if (await _orderService.HasOpenOrder(userId))
            {
                Order = await _orderService.GetUserOpenOrder(userId);
            }
            else
            {
                Order = _orderService.InsertOrder(new OrderViewModel()
                {
                    UserId = userId,
                    FinalPrice = 0,
                    CreationDate = DateTime.Now
                });
            }

            if (_orderItemService.HasItem(productId, Order.OrderId))
            {
                var orderItem = _orderItemService.GetItemOfOrderByProductId(productId, Order.OrderId);
                orderItem.Count++;
                _orderItemService.UpdateOrderItem(orderItem);
            }
            else
            {
                var item = new OrderItem()
                {
                    ProductId = productId,
                    Count = count,
                    OrderId = Order.OrderId
                };
                if (!string.IsNullOrEmpty(color))
                    item.Color = Enum.Parse<EColor>(color);
                if (!string.IsNullOrEmpty(size))
                    item.Size = Enum.Parse<ESize>(size);
                _orderItemService.InsertOrderItem(item);
            }

            await UpdateOrder(Order.OrderId);

            return ViewComponent("CartPreview");
        }

        async Task<OrderViewModel> UpdateOrder(int orderId)
        {
            var order = await _orderService.GetOrder(orderId);
            var orderItems = _orderItemService.GetItemsOfOrder(order.OrderId);

            order.TotalPrice = orderItems.Sum(i => i.Product.Price * i.Count);
            int discountPrice = 0;
            orderItems.Where(i => i.Product.Discount.HasValue).ToList().ForEach(i =>
            {
                discountPrice += (int)(((i.Product.Price * i.Product.Discount)/100) * i.Count);
            });

            var sumPrice = order.TotalPrice - discountPrice;

            order.FinalPrice = PriceCalculator.CalculateDiscountPrice(sumPrice, order.Discount);
            _orderService.UpdateOrder(order);
            return order;
        }

        [Authorize]
        [Route("/product/increasecartitem/{id}")]
        public async Task<IActionResult> IncreaseCartItem(int id)
        {
            var orderItem = _orderItemService.GetOrderItem(id);
            var product = await _productService.GetProduct(orderItem.ProductId);
            if (product.Remaining <= 0)
                return null;
            orderItem.Count++;
            _orderItemService.UpdateOrderItem(orderItem);

            await UpdateOrder(orderItem.OrderId);
            return ViewComponent("CartPreview");
        }

        [Authorize]
        [Route("/product/decreasecartitem/{id}")]
        public async Task<IActionResult> DecreaseCartItem(int id)
        {
            var orderItem = _orderItemService.GetOrderItem(id);
            if (orderItem.Count > 1)
            {
                orderItem.Count--;
                _orderItemService.UpdateOrderItem(orderItem);
            }
            else
                _orderItemService.DeleteOrderItem(orderItem);
            await UpdateOrder(orderItem.OrderId);
            return ViewComponent("CartPreview");
        }

        [Authorize]
        [Route("/product/removecartitem/{id}")]
        public async Task<IActionResult> RemoveCartItem(int id)
        {
            var orderItem = _orderItemService.GetOrderItem(id);
            _orderItemService.DeleteOrderItem(id);
            await UpdateOrder(orderItem.OrderId);
            return ViewComponent("CartPreview");
        }


        [Authorize]
        [Route("/product/addtowishlist/{id}")]
        public IActionResult AddToWishlist(int id)
        {
            if (!_likedProductService.HasProductInLikes(User.GetUserId(), id))
            {
                _likedProductService.InsertLikedProduct(new LikedProductViewModel()
                {
                    ProductId = id,
                    UserId = User.GetUserId()
                });
            }
            else
            {
                _likedProductService.DeleteLikedProductByProductId(User.GetUserId(),id);
            }

            return ViewComponent("LikedItemsPreview");
        }

        [Authorize]
        [Route("/Product/AddComment/{productId}/{score}/{comment}")]
        public IActionResult AddComment(int productId,int score, string comment)
        {
            _productCommentService.InsertComment(new ProductCommentViewModel()
            {
                ProductId = productId,
                UserId = User.GetUserId(),
                Score = score,
                Text = comment,
                CreationDate = DateTime.Now
            });

            ViewData["success"] = "success";
            return ViewComponent("Comments", new
            {
                productId = productId
            });
        }
        
        [Authorize]
        [Route("/Product/RemoveComment/{commentId}")]
        public async Task<IActionResult> RemoveComment(int commentId)
        {
            var comment = await _productCommentService.GetProductComment(commentId);
            if (comment == null)
                return NotFound();
            _productCommentService.DeleteComment(comment);

            ViewData["success"] = "success";
            return ViewComponent("Comments", new
            {
                productId = comment.ProductId
            });
        }
    }
}
