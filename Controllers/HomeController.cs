using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using CuoiKy_CCMTPTPM.Models;

namespace CuoiKy_CCMTPTPM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<CartItem> _cart = new List<CartItem>
        {
            new CartItem { ProductId = 1, Name = "Prada Paradoxe", Description = "Eau de Parfum", Price = 3500000, Quantity = 1, ImageUrl = "https://images.unsplash.com/photo-1541643600914-78b084683601?auto=format&fit=crop&q=80&w=400" },
            new CartItem { ProductId = 2, Name = "Black Opium", Description = "Yves Saint Laurent", Price = 3500000, Quantity = 1, ImageUrl = "https://images.unsplash.com/photo-1585232351009-aa87416fca90?auto=format&fit=crop&q=80&w=400" },
            new CartItem { ProductId = 3, Name = "Aventus Creed", Description = "For Men", Price = 3500000, Quantity = 1, ImageUrl = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?auto=format&fit=crop&q=80&w=400" },
            new CartItem { ProductId = 4, Name = "Libre YSL", Description = "Eau de Parfum Intense", Price = 3500000, Quantity = 1, ImageUrl = "https://images.unsplash.com/photo-1594035910387-fea47794261f?auto=format&fit=crop&q=80&w=400" }
        };

        private static List<FavoriteItem> _favorites = new List<FavoriteItem>
        {
            new FavoriteItem { ProductId = 4, Name = "Libre YSL", Description = "Eau de Parfum Intense", Price = 3500000, Quantity = 1, ImageUrl = "https://images.unsplash.com/photo-1594035910387-fea47794261f?auto=format&fit=crop&q=80&w=400" }
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View(_cart);
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int delta)
        {
            var item = _cart.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                item.Quantity += delta;
                if (item.Quantity < 1) item.Quantity = 1;
                return Json(new { success = true, quantity = item.Quantity, total = (item.Price * item.Quantity).ToString("N0") + "đ" });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var item = _cart.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                _cart.Remove(item);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public IActionResult Favorites()
        {
            return View(_favorites);
        }

        [HttpPost]
        public IActionResult RemoveFromFavorites(int productId)
        {
            var item = _favorites.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                _favorites.Remove(item);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult UpdateFavoriteQuantity(int productId, int delta)
        {
            var item = _favorites.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                item.Quantity += delta;
                if (item.Quantity < 1) item.Quantity = 1;
                return Json(new { success = true, quantity = item.Quantity, total = (item.Price * item.Quantity).ToString("N0") + "đ" });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, string name, string description, decimal price, string imageUrl)
        {
            var item = _cart.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
            {
                _cart.Add(new CartItem 
                { 
                    ProductId = productId, 
                    Name = name, 
                    Description = description, 
                    Price = price, 
                    Quantity = 1, 
                    ImageUrl = imageUrl 
                });
            }
            else
            {
                item.Quantity++;
            }
            return Json(new { success = true, cartCount = _cart.Count });
        }

        [HttpPost]
        public IActionResult AddToFavorite(int productId, string name, string description, decimal price, string imageUrl)
        {
            var item = _favorites.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
            {
                _favorites.Add(new FavoriteItem 
                { 
                    ProductId = productId, 
                    Name = name, 
                    Description = description, 
                    Price = price, 
                    Quantity = 1, 
                    ImageUrl = imageUrl 
                });
            }
            return Json(new { success = true, favCount = _favorites.Count });
        }

        public IActionResult ProductDetail()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
