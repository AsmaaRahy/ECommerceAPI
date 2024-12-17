using ECommerce.DTO;
using ECommerce.Model;

namespace ECommerce.Service
{
    public static class LaptopImageToDTO
    {
        public static List<LaptopImagesDTO> ConvertList(List<LaptopImages> laptopImages) { 
            List<LaptopImagesDTO> laptopImagesDTOs = new List<LaptopImagesDTO>();
            foreach (var item in laptopImages) {
                LaptopImagesDTO laptopImagesDTO = new LaptopImagesDTO()
                {
                    Id = item.Id,
                    ImageUrl = item.ImageUrl,
                    laptopId = item.laptopId,
                };
                laptopImagesDTOs.Add(laptopImagesDTO);
            }
            return laptopImagesDTOs;
        }

        public static LaptopImagesDTO Convert(LaptopImages laptopImages) {
            LaptopImagesDTO laptopImagesDTO = new LaptopImagesDTO()
            {
                Id = laptopImages.Id,
                ImageUrl = laptopImages.ImageUrl,
                laptopId = laptopImages.laptopId
            };
            return laptopImagesDTO;
        }
         

    }
}
