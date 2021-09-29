using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.DTOs;
using ShopMarket.Core.DTOs.ProductDto;
using ShopMarket.Core.DTOs.UserDTOs;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.Utilities.Mappers;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Domain.ShopEntities.OrderEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Core.Services.ShopServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductDto GetAll(ProductFilter filter)
        {
            var products = _productRepository.GetAll();

            int pageCount = 1;
            
            if(!string.IsNullOrWhiteSpace(filter.Search))
                products = products.Where(p => p.Title.Contains(filter.Search) ||
                                               p.Tags.Contains(filter.Search) ||
                                               p.Description.Contains(filter.Search)).Distinct();

            if (filter.CategoryId != null)
                products = products.Where(p => p.CategoryId == filter.CategoryId);

            if (filter.StoreId != null)
                products = products.Where(p => p.StoreId == filter.StoreId);

            if (filter.JustIsAvailable)
                products = products.Where(p => p.Remaining > 0);

            if (filter.Color != null)
                products = products.Where(p => p.AvailableProductColors.Select(av=>av.Color).Contains(filter.Color.Value));

            if (filter.Size != null)
                products = products.Where(p => p.AvailableProductSizes.Select(av => av.Size).Contains(filter.Size.Value));

            if (filter.MinimumPrice != null)
                products = products.Where(p => p.Price >= filter.MinimumPrice);
            if (filter.MaximumPrice != null)
                products = products.Where(p => p.Price <= filter.MaximumPrice);
            if (filter.Remaining != null)
                products = products.Where(p => p.Remaining <= filter.Remaining);

            if (filter.OrderByType != null)
            {
                products = filter.OrderByType switch
                {
                    (EOrderByType.Date, EOrderBy.Descending) => products.OrderByDescending(p => p.CreationDate),
                    (EOrderByType.Price, EOrderBy.Descending) => products.OrderByDescending(p => p.Price),
                    (EOrderByType.Score, EOrderBy.Descending) => products.OrderByDescending(p => p.Score),
                    (EOrderByType.Visit, EOrderBy.Descending) => products.OrderByDescending(p => p.Visit),

                    (EOrderByType.Date, EOrderBy.Ascending) => products.OrderBy(p => p.CreationDate),
                    (EOrderByType.Price, EOrderBy.Ascending) => products.OrderBy(p => p.Price),
                    (EOrderByType.Score, EOrderBy.Ascending) => products.OrderBy(p => p.Score),
                    (EOrderByType.Visit, EOrderBy.Ascending) => products.OrderBy(p => p.Visit),
                    _ => products.OrderByDescending(p => p.Visit)
                };
            }

            int skip = (filter.PageId - 1) * filter.Take;

            pageCount = Convert.ToInt32(Math.Ceiling(((float)products.Count() / filter.Take)));

            products = products.Skip(skip).Take(filter.Take);

            return new ProductDto()
            {
                Products = products.Select(p=>p.MapToViewModel()),
                Filter = filter,
                PageCount = pageCount
            };
        }

        public ProductDto GetProductsByCategory(int categoryId, ProductFilter filter)
        {
            filter.CategoryId = categoryId;
            var productDto = GetAll(filter);

            int pageCount = productDto.Products.Count() / filter.Take;

            return new ProductDto()
            {
                Products = productDto.Products,
                PageCount = pageCount,
                Filter = filter
            };
        }

        public IQueryable<ProductViewModel> GetDeletedProducts()
        {
            return _productRepository.GetDeletedProducts().Select(p => p.MapToViewModel());
        }

        public async Task<ProductViewModel> GetProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);
            return product.MapToViewModel();
        }

        public async Task<ProductViewModel> GetProductByShortLink(string shortLink)
        {
            var product = await _productRepository.GetProductByShortLink(shortLink);
            if (product == null)
                return null;
            return product.MapToViewModel();
        }

        public int InsertProduct(ProductViewModel product)
        {
            product.ShortLink = GenerateShortLink();
            return _productRepository.InsertProduct(product.MapToProduct());
        }

        private string GenerateShortLink()
        {
            string shortLink = "";
            do
            {
                shortLink = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 4);
            } while (DoesLinkExists(shortLink));

            return shortLink;
        }

        public bool DoesLinkExists(string link)
        {
            return _productRepository.DoesLinkExists(link);
        }

        public OperationResult UpdateProduct(ProductViewModel product)
        {
            try
            {
                if (product == null)
                    return OperationResult.NotFound();
                if (string.IsNullOrEmpty(product.ShortLink))
                {
                    product.ShortLink = GenerateShortLink();
                }
                _productRepository.UpdateProduct(product.MapToProduct());
                _productRepository.Save();
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult DeleteProduct(ProductViewModel product)
        {
            try
            {
                if (product == null)
                    return OperationResult.NotFound();
                _productRepository.DeleteProduct(product.MapToProduct());
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public async Task<OperationResult> DeleteProduct(int id)
        {
            try
            {
                if (id == null)
                    return OperationResult.NotFound();
                var product = await GetProduct(id);
                _productRepository.DeleteProduct(product.MapToProduct());
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
        
        public ProductDto GetProductsByStore(int storeId, ProductFilter filter)
        {
            filter.StoreId = storeId;
            var productDto = GetAll(filter);

            return new ProductDto()
            {
                Products = productDto.Products,
                PageCount = productDto.PageCount,
                Filter = filter
            };
        }

        public async Task<OperationResult> AddVisitToProduct(int productId)
        {
            try
            {
                var product = await GetProduct(productId);

                product.Visit++;

                UpdateProduct(product);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult DecreaseProductsCount(List<OrderItem> items)
        {
            foreach (var item in items)
            {
                var product = item.Product;
                product.Remaining -= item.Count;
                _productRepository.UpdateProduct(product);
            }
            _productRepository.Save();

            return OperationResult.Success();
        }

        public IQueryable<ProductViewModel> GetShowInSliderProducts()
        {
            return _productRepository.GetShowInSliderProducts().Select(p=>p.MapToViewModel());
        }

        public IQueryable<ProductViewModel> GetMostVisitedProducts()
        {
            return _productRepository.GetMostVisitedProducts().Select(p=>p.MapToViewModel());
        }

        public IQueryable<ProductViewModel> GetSpecialProducts()
        {
            return _productRepository.GetSpecialProducts().Select(p => p.MapToViewModel());
        }

        public async Task<OperationResult> ReActivateProduct(int id)
        {
            var product = await GetProduct(id);
            _productRepository.ReActivateProduct(product.MapToProduct());
            return OperationResult.Success();
        }
    }
}