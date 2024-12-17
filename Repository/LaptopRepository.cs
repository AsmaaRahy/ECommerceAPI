using ECommerce.Data;
using ECommerce.IRepository;
using ECommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository
{
    public class LaptopRepository : ILaptopRepository
    {
        ApplicationDbContext context;
        public LaptopRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Laptop laptop)
        {
            context.Laptops.Add(laptop);
            context.SaveChanges();
        }
        public async Task< List<Laptop>> ReadAll()
        {
            return await context.Laptops.Include(e=>e.Category).Include(e=>e.ProductImages).ToListAsync();
        }
        public Laptop FindById(int id)
        {
            return context.Laptops.Include(e => e.Category).Include(e=>e.ProductImages).FirstOrDefault(e=>e.Id == id);
        }
        public List<Laptop> FindByCatId(int catId)
        {
            return context.Laptops.Include(e => e.Category).Where(e=> e.CategoryID == catId).ToList();
        }
        public void Update(Laptop laptop)
        {
            var oldLap = context.Laptops.Find(laptop.Id);
            if (oldLap != null) {
                oldLap.Name = laptop.Name;
                oldLap.Price = laptop.Price;
                oldLap.Description = laptop.Description;
                oldLap.Discount = laptop.Discount;
                oldLap.Model = laptop.Model;
                oldLap.CategoryID = laptop.CategoryID;
                context.SaveChanges();
            }

        }
        public void Delete(Laptop laptop)
        {
            context.Laptops.Remove(laptop);
            context.SaveChanges();
        }

        public async Task<List<Laptop>> SearchByName(string name)
        {
            return await context.Laptops
                        .Include(l => l.Category) // Include related category
                        .Where(l => l.Name.Contains(name)) // Filter by name
                        .ToListAsync();
        }

        public async Task<List<Laptop>> GetLaptopsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return await context.Laptops
                .Include(e => e.Category)
                .Include(e => e.ProductImages)
                .Where(l => l.Price >= minPrice && l.Price <= maxPrice)
                .ToListAsync();
        }
    }
}
