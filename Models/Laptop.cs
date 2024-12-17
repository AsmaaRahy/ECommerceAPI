namespace ECommerce.Model
{
    public class Laptop
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<LaptopImages> ProductImages { get; set; } = new List<LaptopImages>();
        public string Model { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public Category Category { get; set; } = null!;

    }
}
