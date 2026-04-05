using System.Collections.Generic;

namespace CuoiKy_CCMTPTPM.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Price * Quantity;
        public bool Selected { get; set; } = true;
    }

    public class FavoriteItem
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; } = 1; // In the screenshot, Favorites also has quantity
        public decimal Total => Price * Quantity;
    }

    public class LoginViewModel
    {
        public string EmailOrPhone { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class ProfileViewModel
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string ActiveTab { get; set; } = "Personal";
        public List<UserOrder> Orders { get; set; }
        public List<UserAddress> Addresses { get; set; }
        public LoyaltyInfo Loyalty { get; set; }
    }

    public class UserOrder
    {
        public string OrderId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public string ItemsSummary { get; set; }
    }

    public class UserAddress
    {
        public string Type { get; set; } // Home, Work
        public string ReceiverName { get; set; }
        public string Phone { get; set; }
        public string AddressDetail { get; set; }
        public bool IsDefault { get; set; }
    }

    public class LoyaltyInfo
    {
        public string Rank { get; set; }
        public int Points { get; set; }
        public decimal DiscountPercent { get; set; }
        public List<string> Benefits { get; set; }
    }

    public class AdminProductViewModel
    {
        public int TotalSKUs { get; set; }
        public int OutOfStock { get; set; }
        public string BestSellerName { get; set; }
        public int BestSellerUnits { get; set; }
        public List<ProductItem> InventoryList { get; set; }
    }

    public class AdminDashboardViewModel
    {
        public decimal TotalRevenue { get; set; }
        public int TotalOrders { get; set; }
        public int TotalCustomers { get; set; }
        public decimal RevenueGrowth { get; set; }
        public List<RecentOrder> RecentOrders { get; set; }
        public List<TopProduct> TopProducts { get; set; }
    }

    public class RecentOrder
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }

    public class TopProduct
    {
        public string Name { get; set; }
        public int UnitsSold { get; set; }
        public decimal Revenue { get; set; }
    }

    public class AdminOrdersViewModel
    {
        public List<RecentOrder> Orders { get; set; }
    }

    public class AdminCustomersViewModel
    {
        public List<CustomerItem> Customers { get; set; }
    }

    public class CustomerItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalSpent { get; set; }
        public DateTime LastOrderDate { get; set; }
    }

    public class ProductItem
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string StockStatus { get; set; }
        public int StockQuantity { get; set; }
        public string ImageType { get; set; } // "wooden", "floral", "fresh"
    }
}
