using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OnlineFoodDeliverySystem.Models.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }

        public virtual DbSet<RestaurantDetails> RestaurantDetails { get; set; }
        public virtual DbSet<MenuItemsList> MenuDetails { get; set; } 
        public DbSet<CustomUserTable> CustomUserDetails { get; set; }
        public DbSet<Rating> Rating { get; set; }

        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<DeliveryDetails> DeliveryDetails { get; set; }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name="Admin", ConcurrencyStamp="1", NormalizedName="Admin"},
                new IdentityRole() { Name = "User", ConcurrencyStamp = "1", NormalizedName = "User" }
           
                );

        }
    }
   


}
