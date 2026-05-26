namespace EfOne.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; }

        public List<Product> Products { get; set; } = new();
    }
}