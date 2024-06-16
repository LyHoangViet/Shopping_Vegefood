using Microsoft.EntityFrameworkCore;
using Shoping_vegefood.Models;

namespace Shoping_vegefood.Repository
{
    public class SeedData
    {
        public static void SeedingData(DataContext _context)
        {
            _context.Database.Migrate();
            if(!_context.Products.Any())
            {
                ShopModel fruits = new ShopModel { Name = "Fruits", Slug = "fruits", Description = "Fruits our is freshest and tastiest", Status = 1 };
                ShopModel vegetables = new ShopModel { Name = "Vegetables", Slug = "vegetables", Description = "Vegetables our is freshest and tastiest", Status = 1 };
                ShopModel juices = new ShopModel { Name = "Juices", Slug = "juices", Description = "Juices our is freshest and tastiest", Status = 1 };
                ShopModel dried = new ShopModel { Name = "Dried", Slug = "dried", Description = "Dried our is freshest and tastiest", Status = 1 };
                BrandModel tomatoe = new BrandModel { Name = "Tomatoe", Slug = "tomatoe", Description = "Tomatoe our is freshest and tastiest", Status = 1 };
                BrandModel salad = new BrandModel { Name = "Salad", Slug = "salad", Description = "Salad our is freshest and tastiest", Status = 1 };
                BrandModel orangejuice = new BrandModel { Name = "Orange juice", Slug = "orangejuice", Description = "Orange juice our is freshest and tastiest", Status = 1 };


                _context.Products.AddRange(
                    new ProductModel { Name = "Cà chua", Slug = "cachua", Description = "Cà chua is the best", Image = "product-5", Shop = fruits, Brand = tomatoe, Price = 20 },
                    new ProductModel { Name = "Xà lách", Slug = "xalach", Description = "Xà lách is the best", Image = "product-5", Shop = vegetables, Brand = salad, Price = 15 },
                    new ProductModel { Name = "Nước Cam", Slug = "nuoccam", Description = "Nước Cam is the best", Image = "product-5", Shop = juices, Brand = orangejuice, Price = 10 }

                );
                _context.SaveChanges();

            }    
        }
    }
}
