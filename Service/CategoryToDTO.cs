using ECommerce.DTO;
using ECommerce.Model;

namespace ECommerce.Service
{
    public static class CategoryToDTO
    {
        public static List<CategoryDTO> ConvertList(List<Category> categories) { 

            List<CategoryDTO > CategoryDTOs = new List<CategoryDTO>();
            foreach (var item in categories) {
                CategoryDTO categoryDTO = new CategoryDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                CategoryDTOs.Add(categoryDTO);
            }
            return CategoryDTOs;
        }

        public static CategoryDTO Convert(Category category) {

            CategoryDTO categoryDTO = new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                
            };
            return categoryDTO;
        }
    }
}
