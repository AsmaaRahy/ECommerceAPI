using ECommerce.Data;
using ECommerce.IRepository;
using ECommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly ApplicationDbContext context;
        public ContactUsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(ContactUs contactUs)
        {
            context.ContactUss.Add(contactUs);
            context.SaveChanges();
        }

        public async Task<List<ContactUs>> ReadAll()
        {
            return await context.ContactUss.ToListAsync();
        }

        public ContactUs FindById(int id)
        {
            return context.ContactUss.Find(id);
        }

        public ContactUs FindByName(string name)
        {
            return context.ContactUss.FirstOrDefault(e=>e.Name == name);
        }

        public void Update(ContactUs contactUs)
        {
            var oldMessage= context.ContactUss.Find(contactUs.Id);
            if (oldMessage != null) { 
                oldMessage.Message= contactUs.Message;
                oldMessage.Subject = contactUs.Subject;
                oldMessage.Status = contactUs.Status;
                context.SaveChanges();
            }
        }
        public void Delete(ContactUs contactUs)
        {
            context.ContactUss.Remove(contactUs);
            context.SaveChanges();
        }
    }
}
