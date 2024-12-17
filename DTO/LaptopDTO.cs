using ECommerce.Model;

namespace ECommerce.DTO
{
    public class LaptopDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();

    }
}
