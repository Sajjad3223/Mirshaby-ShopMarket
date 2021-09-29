using Microsoft.Extensions.DependencyInjection;
using ShopMarket.Core.Interfaces;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Services;
using ShopMarket.Core.Services.FileManager;
using ShopMarket.Core.Services.ShopServices;
using ShopMarket.Core.Services.ShopServices.OrderServices;
using ShopMarket.Core.Services.ShopServices.ProductServices;
using ShopMarket.Core.Services.UserServices;
using ShopMarket.Core.Utilities.Convertors;
using ShopMarket.Core.Utilities.Sernders;
using ShopMarket.Domain.Interfaces.ShopInterfaces;
using ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces;
using ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Infra.Data.Repositories.ShopRepositories;
using ShopMarket.Infra.Data.Repositories.ShopRepositories.OrderRepositories;
using ShopMarket.Infra.Data.Repositories.ShopRepositories.ProductRepositories;
using ShopMarket.Infra.Data.Repositories.UserRepositories;

namespace ShopMarket.Infra.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            #region ShopServices

            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IShopCategoryService, ShopCategoryService>();
            services.AddScoped<IDiscountCodeService, DiscountCodeService>();

            services.AddScoped<ITicketService, TicketService>();

            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<IMainPageDetailService, MainPageDetailService>();

            #region OrderServices

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();

            #endregion

            #region ProductServices

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IProductCommentService, ProductCommentService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();

            services.AddScoped<IAvailableProductColorService, AvailableProductColorService>();
            services.AddScoped<IAvailableProductSizeService, AvailableProductSizeService>();

            #endregion

            #endregion

            #region UserServices

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserAddressService, UserAddressService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRecentVisitService, RecentVisitService>();
            services.AddScoped<ILikedProductService, LikedProductService>();
            services.AddScoped<IOrderHandler, OrderHandler>();

            #endregion

            services.AddScoped<IFileManager, FileManager>();

            services.AddScoped<IEmailSender, GmailSender>();

            services.AddScoped<IViewRenderService, RenderViewToString>();

            #endregion

            #region Repositories


            #region ShopRepositorys

            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IShopCategoryRepository, ShopCategoryRepository>();
            services.AddScoped<IDiscountCodeRepository, DiscountCodeRepository>();

            services.AddScoped<ITicketRepository, TicketRepository>();

            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IMainPageDetailRepository, MainPageDetailRepository>();

            #region OrderRepositorys

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            #endregion

            #region ProductRepositorys

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<IProductCommentRepository, ProductCommentRepository>();
            services.AddScoped<IProductDetailRepository, ProductDetailRepository>();

            services.AddScoped<IAvailableProductColorRepository, AvailableProductColorRepository>();
            services.AddScoped<IAvailableProductSizeRepository, AvailableProductSizeRepository>();

            #endregion

            #endregion

            #region UserRepositorys

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRecentVisitRepository, RecentVisitRepository>();
            services.AddScoped<ILikedProductRepository, LikedProductRepository>();

            #endregion


            #endregion
        }

    }
}