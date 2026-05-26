namespace EfOne.Dtos;

public class ProductDetailedDto
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public bool IsDeleted { get; set; }

    public string CategoryName { get; set; } = null!;

    public string BrandName { get; set; } = null!;
}