using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Domain.ShopEntities.OrderEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;
using ShopMarket.Domain.UserEntities;
using ShopMarket.Domain.UserEntities.Permissions;

namespace ShopMarket.Infra.Data.ShopMarketContext
{
    public class ShopMarketDbContext : DbContext
    {
        public ShopMarketDbContext(DbContextOptions<ShopMarketDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<LikedProduct> LikedProducts { get; set; }
        public DbSet<UserAddress> Addresses { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<RecentVisit> RecentVisits { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Ticket> Tickets{ get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<AvailableProductColor> AvailableProductColors { get; set; }
        public DbSet<AvailableProductSize> AvailableProductSizes { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Slide> Slides{ get; set; }
        public DbSet<Banner> Banners{ get; set; }
        public DbSet<MainPageDetail> MainPageDetails{ get; set; }

        public DbSet<DiscountCode> DiscountCodes { get; set; }
        public DbSet<ShopCategory> ShopCategories { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ProductComment>().HasQueryFilter(pc => !pc.IsDeleted);
            modelBuilder.Entity<Order>().HasQueryFilter(o => !o.IsDeleted);
            modelBuilder.Entity<ShopCategory>().HasQueryFilter(shc => !shc.IsDeleted);
            modelBuilder.Entity<Store>().HasQueryFilter(s => !s.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }
    }
}