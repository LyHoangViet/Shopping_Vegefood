using Microsoft.AspNetCore.Mvc;
using Shoping_vegefood.Models;
using Shoping_vegefood.Models.ViewModels;
using Shoping_vegefood.Repository;
using System.Collections.Generic;

namespace Shoping_vegefood.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _dataContext;
        public CartController(DataContext _context)
        {
            _dataContext = _context;
        }

        public IActionResult Index()
        {
            List<CartitemModel> cartitems = HttpContext.Session.GetJson<List<CartitemModel>>("Cart") ?? new List<CartitemModel>();
            CartitemViewModel cartvn = new()
            {
                Cartitems = cartitems,
                GrandTotal = cartitems.Sum(x => x.Quantity * x.Price)

            };
            return View(cartvn);
        }

        public IActionResult Checkout()
        {
            return View("~/Views/Checkout/Index.cshtml");
        }
        public async Task<IActionResult> add(int Id)
        {
            ProductModel product = await _dataContext.Products.FindAsync(Id);
            List<CartitemModel> cart = HttpContext.Session.GetJson<List<CartitemModel>>("Cart") ?? new List<CartitemModel>();
            CartitemModel cartitem = cart.Where(c => c.ProductId == Id).FirstOrDefault();
            if (cartitem == null)
            {
                cart.Add(new CartitemModel(product));
            }
            else
            {
                cartitem.Quantity += 1;
            }
            HttpContext.Session.SetJson("Cart", cart);

            TempData["success"] = "Add item to cart Successfully";
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> Remove(int Id)
        {
            List<CartitemModel> cart = HttpContext.Session.GetJson<List<CartitemModel>>("Cart");
            cart.RemoveAll(p => p.ProductId == Id);
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["success"] = "Remove item of cart Successfully";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Clear(int Id)
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }
    }
}
