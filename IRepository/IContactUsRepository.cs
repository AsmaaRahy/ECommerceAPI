using ECommerce.Model;

namespace ECommerce.IRepository
{
    public interface IContactUsRepository
    {
        void Create(ContactUs contactUs);
        Task<List<ContactUs>> ReadAll();
        ContactUs FindById(int id);
        ContactUs FindByName(string name);
        void Update(ContactUs contactUs);
        void Delete(ContactUs contactUs);
    }
}
