using ECommerce.Model;

namespace ECommerce.IRepository
{
    public interface ICategoryRepository
    {
        //CRUD
        void Create(Category category);
        Task<List<Category>> ReadAll();
        Category FindById(int id);
        void Update(Category category);
        void Delete(Category category);


    }
}
