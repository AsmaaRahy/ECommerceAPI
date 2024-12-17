using ECommerce.DTO;
using ECommerce.Model;

namespace ECommerce.Service
{
    public static class ContactUsToDTO
    {
        public static List<ContactUsDTO> ConvertList(List<ContactUs> contactsUs)
        {
            List<ContactUsDTO> contactUsDTOs = new List<ContactUsDTO>();
            foreach (var item in contactsUs)
            {
                ContactUsDTO contactUs = new ContactUsDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Message = item.Message,
                    Subject = item.Subject,
                    Status = item.Status
                };
                contactUsDTOs.Add(contactUs);

            }
            return contactUsDTOs;
        }

        public static ContactUsDTO Convert(ContactUs contactUs) {

            ContactUsDTO contactUsDTO = new ContactUsDTO()
            {
                Id = contactUs.Id,
                Name = contactUs.Name,
                Email = contactUs.Email,
                Message = contactUs.Message,
                Subject = contactUs.Subject,
                Status = contactUs.Status,
            };
            return contactUsDTO;
        }
    }
}
