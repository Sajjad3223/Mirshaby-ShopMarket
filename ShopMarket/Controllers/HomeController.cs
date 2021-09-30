using Microsoft.AspNetCore.Mvc;
using ShopMarket.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopMarket.Core.DTOs;
using ShopMarket.Core.DTOs.ProductDto;
using ShopMarket.Core.Interfaces;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.ViewModels;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Controllers
{
    public class HomeController : Controller
    {
        #region Services

        private readonly IProductService _productService;
        private readonly IProductImageService _imageService;
        private readonly IShopCategoryService _shopCategoryService;
        private readonly ITicketService _ticketService;

        #endregion

        #region Inject Services

        public HomeController(IProductService productService, IShopCategoryService shopCategoryService, IProductImageService imageService, ITicketService ticketService)
        {
            _productService = productService;
            _shopCategoryService = shopCategoryService;
            _imageService = imageService;
            _ticketService = ticketService;
        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(int? categoryId ,ProductFilter filter , string? Filter_MinimumPrice , string? Filter_MaximumPrice, string? EOrderByType, string? EOrderBy , string? color)
        {
            ProductDto productDto = new ProductDto();

            #region Fill Filter

            int minimum = 0;
            if (Filter_MinimumPrice != null)
            {
                int.TryParse(Filter_MinimumPrice, NumberStyles.AllowThousands, null, out minimum);
            }
            int maximum = 0;
            if (Filter_MaximumPrice != null)
            {
                int.TryParse(Filter_MaximumPrice, NumberStyles.AllowThousands, null, out maximum);
            }

            EOrderByType orderType = Core.DTOs.EOrderByType.Date;
            if (EOrderByType != null)
            {
                orderType = Enum.Parse<EOrderByType>(EOrderByType);
            }
            EOrderBy orderSort = Core.DTOs.EOrderBy.Descending;
            if (EOrderBy != null)
            {
                orderSort = Enum.Parse<EOrderBy>(EOrderBy);
            }

            if (minimum != 0) filter.MinimumPrice = minimum;
            if (maximum != 0) filter.MaximumPrice = maximum;

            filter.OrderByType = new Tuple<EOrderByType, EOrderBy>(orderType, orderSort);

            if (color != null)
            {
                filter.Color = Enum.Parse<EColor>(color);
            }

            #endregion

            #region Get Products by category Id and filter

            if (categoryId != null)
            {
                var category = await _shopCategoryService.GetCategory(categoryId.Value);
                ViewBag.Category = category;
                productDto = _productService.GetProductsByCategory(categoryId.Value,filter);
                var subCategories = _shopCategoryService.GetSubCategories(category.CategoryId);
                if (subCategories.Any())
                {
                    List<ProductViewModel> childProducts = new List<ProductViewModel>();
                    foreach (var sub in subCategories)
                    {
                        childProducts = childProducts.Union(_productService.GetProductsByCategory(sub.CategoryId, filter).Products).ToList();
                        var subSubCategories = _shopCategoryService.GetSubCategories(sub.CategoryId).ToList();
                        if (subSubCategories.Any())
                        {
                            foreach (var subSub in subSubCategories)
                            {
                                var subSubProducts = _productService.GetProductsByCategory(subSub.CategoryId,filter).Products.ToList();
                                childProducts = childProducts.Union(subSubProducts).ToList();
                            }
                        }
                    }

                    productDto.Products = productDto.Products.Union(childProducts).GroupBy(p => p.ProductId).Select(y => y.FirstOrDefault()).ToList();
                }
                if (category.ParentId != null)
                    ViewBag.ParentCategory = await _shopCategoryService.GetCategory(category.ParentId.Value);
            }

            #endregion

            #region Get All Products by filter

            else
            {
                productDto = _productService.GetAll(filter);
            }

            #endregion

            #region If Any Product Exists Attach Main Images

            if (productDto.Products.Any())
            {
                ViewBag.MaximumPrice = productDto.Products.Max(p => p.Price);
                var products = productDto.Products.ToList();

                foreach (var product in products.ToList())
                {
                    var imageName = await _imageService.GetMainImage(product.ProductId);
                    if (imageName != null) product.MainImage = imageName.ImageName;
                }

                productDto.Products = products;
            }

            #endregion

            ViewData["Categories"] = new SelectList(_shopCategoryService.GetAll(), "CategoryId", "Title");
            
            return View(productDto);
        }

        [Route("/seller/{storeId}/{filter?}")]
        public async Task<IActionResult> StoreItems(int storeId, ProductFilter? filter)
        {
            ProductDto productDto = new ProductDto();
            if (filter == null)
                filter = new ProductFilter();

            productDto = _productService.GetProductsByStore(storeId, filter);

            if (productDto.Products.Any())
            {
                ViewBag.MaximumPrice = productDto.Products.Max(p => p.Price);
                var products = productDto.Products.ToList();

                foreach (var product in products.ToList())
                {
                    var imageName = await _imageService.GetMainImage(product.ProductId);
                    if (imageName != null) product.MainImage = imageName.ImageName;
                }

                productDto.Products = products;
            }

            return View("Search", productDto);
        }

        #region Contact Us


        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(TicketViewModel ticket)
        {
            if (!ModelState.IsValid)
                return View(ticket);

            _ticketService.InsertTicket(ticket);

            ViewBag.Result = "Success";
            return View();
        }


        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("/home/404")]
        public IActionResult NotFoundPath()
        {
            return View();
        }
    }
}
