using ECommerce.Data;
using ECommerce.IRepository;
using ECommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository
{
    public class LaptopImageRepository : ILaptopImageRepository
    {
        private readonly ApplicationDbContext context;

        public LaptopImageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(LaptopImages laptopImage)
        {
            context.LaptopImagess.Add(laptopImage);
            context.SaveChanges();
        }

        public void Delete(LaptopImages laptopImages)
        {
            context.LaptopImagess.Remove(laptopImages);
            context.SaveChanges();
        }

        public LaptopImages FindById(int id)
        {
            return context.LaptopImagess.Find(id);
        }

        public async Task<List<LaptopImages>> ReadAll()
        {
            return await context.LaptopImagess.ToListAsync();
        }

        public void Update(LaptopImages laptopImages)
        {
            var oldImage= context.LaptopImagess.Find(laptopImages.Id);
            if (oldImage != null) { 
                oldImage.ImageUrl = laptopImages.ImageUrl;
                oldImage.laptopId = laptopImages.laptopId;
                context.SaveChanges();
            }
        }
    }
}
