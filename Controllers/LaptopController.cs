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
    public class LaptopController : ControllerBase
    {
        private readonly ILaptopRepository laptopRepository;
        public LaptopController(ILaptopRepository laptopRepository)
        {
            this.laptopRepository = laptopRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            var laptops = await laptopRepository.ReadAll();
            return Ok(LaptopToDTO.ConvertList(laptops));
        }
        [HttpGet("{id}")]
        public IActionResult FindById(int id) {
            var laptop = laptopRepository.FindById(id);
            if (laptop != null) {
                return Ok(LaptopToDTO.Convert(laptop));
            }
            return NotFound();
        }

        [HttpGet("Cat{catId}")]
        public IActionResult FindByCatId(int catId) { 
            var laptops= laptopRepository.FindByCatId(catId);
            if (laptops != null && laptops.Any())
            {
                return Ok(LaptopToDTO.ConvertList(laptops));
            }
            return NotFound();   
        }

        [HttpPost]
        public IActionResult Create(LaptopDTO laptopDTO) {
            if (ModelState.IsValid)
            {
                Laptop laptop = new Laptop()
                {
                    Name = laptopDTO.Name,
                    Description = laptopDTO.Description,
                    Discount = laptopDTO.Discount,
                    Price = laptopDTO.Price,
                    Model = laptopDTO.Model,
                    CategoryID = laptopDTO.CategoryID,
                };
                laptopRepository.Create(laptop);
                return Created($"http://localhost:5251/api/Laptop/{laptop.Id}",laptopDTO);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(LaptopDTO laptopDTO) {
            if (ModelState.IsValid) { 
                var oldLap= laptopRepository.FindById(laptopDTO.Id);
                if (oldLap != null)
                {
                    Laptop laptop = new Laptop()
                    {
                        Id = laptopDTO.Id,
                        Name = laptopDTO.Name,
                        Description = laptopDTO.Description,
                        Discount = laptopDTO.Discount,
                        Price = laptopDTO.Price,
                        Model = laptopDTO.Model,
                        CategoryID = laptopDTO.CategoryID,

                    };
                    laptopRepository.Update(laptop);
                    return Ok(LaptopToDTO.Convert(laptop));
                }
                else { 
                    return NotFound();
                }
                
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id) { 
            var laptop=laptopRepository.FindById(id);
            if(laptop != null)
            {
                laptopRepository.Delete(laptop);
                return Ok(LaptopToDTO.Convert(laptop));
            }
            return NotFound();
        }
        [HttpGet("Search")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var laptops = await laptopRepository.SearchByName(name);
            if (laptops != null && laptops.Any())
            {
                return Ok(LaptopToDTO.ConvertList(laptops));
            }
            return NotFound();
        }


       
        [HttpGet("rating")]
        public async Task<IActionResult> GetLaptopsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            if (minPrice < 0 || maxPrice < 0 || minPrice > maxPrice)
            {
                return BadRequest("Invalid price range.");
            }

            var laptops = await laptopRepository.GetLaptopsByPriceRange(minPrice, maxPrice);

            if (laptops == null || !laptops.Any())
            {
                return NotFound("No laptops found in the given price range.");
            }

            return Ok(LaptopToDTO.ConvertList(laptops));
        }

    }
   
    
}
