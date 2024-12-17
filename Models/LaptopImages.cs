namespace ECommerce.Model
{
    public class LaptopImages
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public Laptop Laptop { get; set; }
        public int laptopId { get; set; }

    }
}
