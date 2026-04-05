using Microsoft.AspNetCore.Mvc;
using CuoiKy_CCMTPTPM.Models;
using System.Collections.Generic;
using System;

namespace CuoiKy_CCMTPTPM.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var model = new AdminDashboardViewModel
            {
                TotalRevenue = 125400000,
                TotalOrders = 452,
                TotalCustomers = 890,
                RevenueGrowth = 12.5m,
                RecentOrders = new List<RecentOrder>
                {
                    new RecentOrder { OrderId = "#ORD-7421", CustomerName = "Lê Huy", Date = DateTime.Now.AddHours(-2), Amount = 3500000, Status = "Completed" },
                    new RecentOrder { OrderId = "#ORD-7420", CustomerName = "Nguyễn Văn A", Date = DateTime.Now.AddHours(-5), Amount = 1200000, Status = "Processing" },
                    new RecentOrder { OrderId = "#ORD-7419", CustomerName = "Trần Thị B", Date = DateTime.Now.AddDays(-1), Amount = 5400000, Status = "Completed" },
                    new RecentOrder { OrderId = "#ORD-7418", CustomerName = "Phạm Văn C", Date = DateTime.Now.AddDays(-1), Amount = 2100000, Status = "Cancelled" }
                },
                TopProducts = new List<TopProduct>
                {
                    new TopProduct { Name = "Velvet Moss", UnitsSold = 425, Revenue = 78625000 },
                    new TopProduct { Name = "Midnight Cedar", UnitsSold = 312, Revenue = 57720000 },
                    new TopProduct { Name = "Aegean Sea", UnitsSold = 285, Revenue = 42750000 }
                }
            };
            return View(model);
        }

        public IActionResult Products()
        {
            var model = new AdminProductViewModel
            {
                TotalSKUs = 1284,
                OutOfStock = 8,
                BestSellerName = "Velvet Moss",
                BestSellerUnits = 425,
                InventoryList = new List<ProductItem>
                {
                    new ProductItem { SKU = "MC-2024-001", Name = "Midnight Cedar", Category = "WOODEN", Price = 185.00m, StockStatus = "In Stock", StockQuantity = 42, ImageType = "wooden" },
                    new ProductItem { SKU = "PM-2024-089", Name = "Petal & Mist", Category = "FLORAL", Price = 145.00m, StockStatus = "Low Stock", StockQuantity = 3, ImageType = "floral" },
                    new ProductItem { SKU = "AS-2024-112", Name = "Aegean Sea", Category = "FRESH", Price = 150.00m, StockStatus = "In Stock", StockQuantity = 128, ImageType = "fresh" }
                }
            };
            return View(model);
        }

        public IActionResult Orders()
        {
            var model = new AdminOrdersViewModel
            {
                Orders = new List<RecentOrder>
                {
                    new RecentOrder { OrderId = "#ORD-7421", CustomerName = "Lê Huy", Date = DateTime.Now.AddHours(-2), Amount = 3500000, Status = "Completed" },
                    new RecentOrder { OrderId = "#ORD-7420", CustomerName = "Nguyễn Văn A", Date = DateTime.Now.AddHours(-5), Amount = 1200000, Status = "Processing" },
                    new RecentOrder { OrderId = "#ORD-7419", CustomerName = "Trần Thị B", Date = DateTime.Now.AddDays(-1), Amount = 5400000, Status = "Completed" },
                    new RecentOrder { OrderId = "#ORD-7418", CustomerName = "Phạm Văn C", Date = DateTime.Now.AddDays(-1), Amount = 2100000, Status = "Cancelled" },
                    new RecentOrder { OrderId = "#ORD-7417", CustomerName = "Hoàng Văn D", Date = DateTime.Now.AddDays(-2), Amount = 800000, Status = "Completed" }
                }
            };
            return View(model);
        }

        public IActionResult Customers()
        {
            var model = new AdminCustomersViewModel
            {
                Customers = new List<CustomerItem>
                {
                    new CustomerItem { Id = "CUST-001", Name = "Lê Huy", Email = "huy.le@example.com", TotalOrders = 12, TotalSpent = 45000000, LastOrderDate = DateTime.Now.AddDays(-2) },
                    new CustomerItem { Id = "CUST-002", Name = "Nguyễn Văn A", Email = "vana@example.com", TotalOrders = 5, TotalSpent = 12500000, LastOrderDate = DateTime.Now.AddDays(-5) },
                    new CustomerItem { Id = "CUST-003", Name = "Trần Thị B", Email = "thib@example.com", TotalOrders = 8, TotalSpent = 22000000, LastOrderDate = DateTime.Now.AddDays(-1) }
                }
            };
            return View(model);
        }
    }
}
