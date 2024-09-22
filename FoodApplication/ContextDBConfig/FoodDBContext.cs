using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FoodApplication.Models;

namespace FoodApplication.ContextDBConfig
{
    public class FoodApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public FoodApplicationDBContext(DbContextOptions<FoodApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Include configuration for the Cart entity
            modelBuilder.Entity<Cart>()
                .Property(c => c.RecipeId)
                .HasMaxLength(255);  // Adjust the length if needed

            // Additional configuration...

            // Ensure the Identity schema is applied correctly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodApplicationDBContext).Assembly);
        }
    }
}
