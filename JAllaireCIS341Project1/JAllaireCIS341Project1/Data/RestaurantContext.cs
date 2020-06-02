using JAllaireCIS341Project1.Models;
using Microsoft.EntityFrameworkCore;

namespace JAllaireCIS341Project1.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {

        }

        // DbSet properties that will be used to query DB
        public DbSet<JAllaireCIS341Project1.Models.CustomerOrder> CustomerOrders { get; set; }
        public DbSet<JAllaireCIS341Project1.Models.MenuItem> MenuItems { get; set; }
        public DbSet<JAllaireCIS341Project1.Models.Ingredient> Ingredients { get; set; }
        public DbSet<JAllaireCIS341Project1.Models.Restaurant> Restaurants { get; set; }
        public DbSet<JAllaireCIS341Project1.Models.OrderItem> OrderItems { get; set; }
        public DbSet<JAllaireCIS341Project1.Models.OrderStatus> OrderStatuses { get; set; }
        public DbSet<JAllaireCIS341Project1.Models.MenuItemIngredient> MenuItemIngredients { get; set; }
        public DbSet<JAllaireCIS341Project1.Models.Employee> Employees { get; set; }
        public DbSet<JAllaireCIS341Project1.Models.EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<JAllaireCIS341Project1.Models.Cart> MyCart { get; set; }
        public DbSet<JAllaireCIS341Project1.Models.CartItem> CartItems { get; set; }
    }
}
