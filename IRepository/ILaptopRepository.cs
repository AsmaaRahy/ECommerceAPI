using ECommerce.Model;

namespace ECommerce.IRepository
{
    public interface ILaptopRepository
    {
        //CRUD

        void Create(Laptop laptop);
        Task<List<Laptop>> ReadAll();
        List<Laptop> FindByCatId(int catId);
        Laptop FindById(int id);

        void Update(Laptop laptop);
        void Delete(Laptop laptop);
        Task<List<Laptop>> SearchByName(string name);
        Task<List<Laptop>> GetLaptopsByPriceRange(decimal minPrice, decimal maxPrice);
    }
}
