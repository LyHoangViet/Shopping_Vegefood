using Microsoft.AspNetCore.Mvc;
using Shoping_vegefood.Repository;

namespace Shoping_vegefood.Controllers
{
    public class ShopController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<ShopController> _logger;

        public ShopController(ILogger<ShopController> logger, DataContext context)
        {
            _logger = logger;
            _dataContext = context;
        }
        public IActionResult Index()
        {
            var products = _dataContext.Products.ToList();
            return View(products);
        }
    }
}
