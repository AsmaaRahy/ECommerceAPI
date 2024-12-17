using ECommerce.DTO;
using ECommerce.Model;

namespace ECommerce.Service
{
    public static class LaptopToDTO
    {
        public static List<LaptopDTO> ConvertList(List<Laptop> laptops) {
            List<LaptopDTO> LaptopDTOs = new List<LaptopDTO>();
            foreach (var item in laptops) {
                LaptopDTO laptopDTO = new LaptopDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Description = item.Description,
                    Discount = item.Discount,
                    Model = item.Model,
                    CategoryID = item.CategoryID,
                    CategoryName = item.Category?.Name,
                    ImageUrls = item.ProductImages.Select(img => img.ImageUrl).ToList()
                };
                LaptopDTOs.Add(laptopDTO);
            }
            return LaptopDTOs;
        }

        public static LaptopDTO Convert(Laptop laptop)
        {
            LaptopDTO laptopDTO = new LaptopDTO()
            {
                Id = laptop.Id,
                Name = laptop.Name,
                Price = laptop.Price,
                Description = laptop.Description,
                Discount = laptop.Discount,
                Model = laptop.Model,
                CategoryID = laptop.CategoryID,
                CategoryName = laptop.Category?.Name,
                ImageUrls = laptop.ProductImages.Select(img => img.ImageUrl).ToList()
            };
            return laptopDTO;
        }

    }
}
