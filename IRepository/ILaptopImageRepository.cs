using ECommerce.Model;

namespace ECommerce.IRepository
{
    public interface ILaptopImageRepository
    {
        void Create(LaptopImages laptopImage);
        Task<List<LaptopImages>> ReadAll();
        void Delete(LaptopImages laptopImages);
        LaptopImages FindById(int id);
        void Update(LaptopImages laptopImages);
    }
}
