using ECommerce.DTO;
using ECommerce.IRepository;
using ECommerce.Model;
using ECommerce.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopImageController : ControllerBase
    {
        private readonly ILaptopImageRepository laptopImageRepository;
        public LaptopImageController(ILaptopImageRepository laptopImageRepository)
        {
            this.laptopImageRepository = laptopImageRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            var images= await laptopImageRepository.ReadAll();
            return Ok(LaptopImageToDTO.ConvertList(images));
        }
        [HttpPost]
        public IActionResult Create(LaptopImagesDTO laptopImagesDTO)
        {
            if (ModelState.IsValid)
            {
                LaptopImages images = new LaptopImages()
                {
                    ImageUrl = laptopImagesDTO.ImageUrl,
                    laptopId = laptopImagesDTO.laptopId,
                };
                laptopImageRepository.Create(images);
                return Ok(LaptopImageToDTO.Convert(images));
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(LaptopImagesDTO laptopImagesDTO)
        {
            if (ModelState.IsValid)
            {
                var oldImage = laptopImageRepository.FindById(laptopImagesDTO.Id);
                if(oldImage != null)
                {
                    LaptopImages laptopImages = new LaptopImages()
                    {
                        Id = laptopImagesDTO.Id,
                        ImageUrl = laptopImagesDTO.ImageUrl,
                        laptopId= laptopImagesDTO.laptopId,
                    };
                    laptopImageRepository.Update(laptopImages);
                    return Ok(LaptopImageToDTO.Convert(laptopImages));
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
            var image = laptopImageRepository.FindById(id);
            if (image != null) {
                laptopImageRepository.Delete(image);
                return Ok(LaptopImageToDTO.Convert(image));
            }
            return NotFound();
        }

    }
}
