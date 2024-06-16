using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shoping_vegefood.Models;

namespace Shoping_vegefood.Repository
{
    public class DataContext : IdentityDbContext<AppUserModel>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<BrandModel> Brands { get; set; } 
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ShopModel> Shops { get; set; }

    }
}
