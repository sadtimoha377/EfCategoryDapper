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

    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;
}