using DrinkAndGoMVC.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Identity.Client;

namespace DrinkAndGoMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}
    }
}
