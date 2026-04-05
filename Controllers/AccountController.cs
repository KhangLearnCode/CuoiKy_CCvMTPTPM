using Microsoft.AspNetCore.Mvc;
using CuoiKy_CCMTPTPM.Models;

namespace CuoiKy_CCMTPTPM.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // In a real app, verify user credentials here
                // For demo purposes, we'll just redirect to Profile
                return RedirectToAction("Profile");
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // In a real app, create the user here
                return RedirectToAction("Login");
            }
            return View(model);
        }

        public IActionResult Profile(string tab = "Personal")
        {
            // Demo data
            var model = new ProfileViewModel
            {
                FullName = "Alexander V. Thorne",
                PhoneNumber = "+1 (555) 892-0431",
                Email = "alexander.thorne@ethereal.com",
                DateOfBirth = "May 24, 1992",
                ActiveTab = tab,
                Orders = new List<UserOrder>
                {
                    new UserOrder { OrderId = "#ORD-7421", Date = DateTime.Now.AddDays(-2), Total = 3500000, Status = "Completed", ItemsSummary = "Prada Paradoxe x1" },
                    new UserOrder { OrderId = "#ORD-7419", Date = DateTime.Now.AddDays(-10), Total = 5400000, Status = "Completed", ItemsSummary = "Aventus Creed x1, Libre YSL x1" }
                },
                Addresses = new List<UserAddress>
                {
                    new UserAddress { Type = "Home", ReceiverName = "Alexander V. Thorne", Phone = "+1 (555) 892-0431", AddressDetail = "123 Main St, New York, NY 10001", IsDefault = true },
                    new UserAddress { Type = "Work", ReceiverName = "Alex Thorne", Phone = "+1 (555) 123-4567", AddressDetail = "456 Office Plaza, Brooklyn, NY 11201", IsDefault = false }
                },
                Loyalty = new LoyaltyInfo
                {
                    Rank = "Gold Member",
                    Points = 1250,
                    DiscountPercent = 5.0m,
                    Benefits = new List<string> { "Free Shipping", "Birthday Gift", "Early Access to New Releases" }
                }
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateProfile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Update profile logic
                return RedirectToAction("Profile");
            }
            return View("Profile", model);
        }
    }
}
