namespace ECommerce.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Laptop> Laptops { get; set; } = new HashSet<Laptop>();

    }
}
