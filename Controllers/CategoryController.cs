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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll() { 
            var categories= await categoryRepository.ReadAll();
            return Ok(CategoryToDTO.ConvertList(categories));

        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id) { 
            var category= categoryRepository.FindById(id);
            if (category != null) {
                return Ok(CategoryToDTO.Convert(category));
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(CategoryDTO categoryDTO) {
            if (ModelState.IsValid)
            {
                Category category = new Category()
                {
                    Name = categoryDTO.Name,
                };
                categoryRepository.Create(category);
                return Created($"http://localhost:5251/api/Category/{category.Id}",categoryDTO);
            }
            return BadRequest();
            
        }

        [HttpPut]
        public IActionResult Update(CategoryDTO categoryDTO) {
            if (ModelState.IsValid) { 
                var oldCat= categoryRepository.FindById(categoryDTO.Id);
                if (oldCat != null) {
                    Category category = new Category()
                    {
                        Id = oldCat.Id,
                        Name = categoryDTO.Name,
                    };
                    categoryRepository.Update(category);
                    return Ok(CategoryToDTO.Convert(category));
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
            var category= categoryRepository.FindById(id);
            if (category != null) { 
                categoryRepository.Delete(category);
                return Ok(CategoryToDTO.Convert(category));
            }
            return NotFound();
        }


    }
}
