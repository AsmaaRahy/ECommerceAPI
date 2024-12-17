using ECommerce.Data;
using ECommerce.IRepository;
using ECommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Category category) {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public async Task<List<Category>> ReadAll()
        {
            return await context.Categories.ToListAsync();
        }

        public Category FindById(int id)
        {
            return context.Categories.Find(id);
        }
        public void Update(Category category)
        {
            var oldCat= context.Categories.Find(category.Id);
            if (oldCat != null) { 
                oldCat.Name = category.Name;
                context.SaveChanges();
            }
        }
        public void Delete(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        
    }
}
