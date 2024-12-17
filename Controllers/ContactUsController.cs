using ECommerce.DTO;
using ECommerce.IRepository;
using ECommerce.Model;
using ECommerce.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsRepository contactUsRepository;
        public ContactUsController(IContactUsRepository contactUsRepository)
        {
            this.contactUsRepository = contactUsRepository;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> ReadAll()
        {
            var contactUs= await contactUsRepository.ReadAll();
            return Ok(ContactUsToDTO.ConvertList(contactUs));
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id) { 
            var contactUs= contactUsRepository.FindById(id);
            if (contactUs != null) {
                return Ok(ContactUsToDTO.Convert(contactUs));
            }
            return NotFound();
        }

        [HttpGet("Name{name}")]
        public IActionResult FindByName(string name) { 
            var contactUs = contactUsRepository.FindByName(name);
            if (contactUs != null) {
                return Ok(ContactUsToDTO.Convert(contactUs));
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(ContactUsDTO contactUsDTO) {
            if (ModelState.IsValid)
            {
                ContactUs contactUs = new ContactUs()
                {
                    Name = contactUsDTO.Name,
                    Email = contactUsDTO.Email,
                    Message = contactUsDTO.Message,
                    Subject = contactUsDTO.Subject,
                    Status = contactUsDTO.Status,
                };
                contactUsRepository.Create(contactUs);
                return Ok(contactUs);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(ContactUsDTO contactUsDTO) {
            if (ModelState.IsValid) { 
                var oldContactUs = contactUsRepository.FindById(contactUsDTO.Id);
                if (oldContactUs != null) {
                    ContactUs contactUs = new ContactUs()
                    {

                        Id = contactUsDTO.Id,
                        Name = oldContactUs.Name,
                        Email = oldContactUs.Email,
                        Message = contactUsDTO.Message,
                        Subject = contactUsDTO.Subject,
                        Status = contactUsDTO.Status,
                    };
                    contactUsRepository.Update(contactUs);
                    return Ok(ContactUsToDTO.Convert(contactUs));
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            var contactUs= contactUsRepository.FindById(id);
            if (contactUs != null) { 
                contactUsRepository.Delete(contactUs);
                return Ok(ContactUsToDTO.Convert(contactUs));
            }
            return NotFound();
        }
    }
}
