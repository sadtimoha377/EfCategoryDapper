using System;
using System.Collections.Generic;
using System.Text;

namespace EfOne.Models;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTime? DeletedAt { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    public int BrandId { get; set; }

    public Brand Brand { get; set; } = null!;
}