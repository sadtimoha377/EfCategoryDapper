using System;
using System.Collections.Generic;
using System.Text;

namespace EfOne.Models;

public class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public List<Product> Products { get; set; } = new();
}