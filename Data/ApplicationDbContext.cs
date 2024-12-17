using ECommerce.DTO;
using ECommerce.Model;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    
    {
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactUs> ContactUss { get; set; }
        public DbSet<LaptopImages> LaptopImagess { get; set; }

        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(builder);
        }
        public DbSet<ApplicationUserDTO> ApplicationUserDTO { get; set; } = default!;
    }
}
