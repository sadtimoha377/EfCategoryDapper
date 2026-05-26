using EfOne.Data;
using EfOne.Models;

bool isRunning = true;

while (isRunning)
{
    Console.WriteLine("\n===== MENU =====");
    Console.WriteLine("1 - Get all categories");
    Console.WriteLine("2 - Add category");
    Console.WriteLine("3 - Delete category");
    Console.WriteLine("4 - Find by ID");
    Console.WriteLine("5 - Find by name");
    Console.WriteLine("6 - Update category");
    Console.WriteLine("7 - Create product");
    Console.WriteLine("8 - Edit product");
    Console.WriteLine("9 - Delete product");
    Console.WriteLine("10 - Show products by categories");
    Console.WriteLine("11 - Product count in categories");
    Console.WriteLine("12 - Cheapest product in categories");
    Console.WriteLine("13 - Average price in categories");
    Console.WriteLine("14 - Show deleted products");
    Console.WriteLine("0 - Exit");

    Console.Write("Your choice: ");
    string? choice = Console.ReadLine();

    using AppDbContext db = new();

    switch (choice)
    {
        case "1":
            {
                var categories = db.Categories.ToList();

                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.Id} | {category.Name} | {category.Description}");
                }

                break;
            }

        case "2":
            {
                Console.Write("Name: ");
                string? name = Console.ReadLine();

                Console.Write("Description: ");
                string? description = Console.ReadLine();

                Category category = new()
                {
                    Name = name!,
                    Description = description!,
                    CreatedAt = DateTime.Now
                };

                db.Categories.Add(category);
                db.SaveChanges();

                Console.WriteLine("Category added!");
                break;
            }

        case "3":
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine()!);

                var category = db.Categories.Find(id);

                if (category != null)
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();

                    Console.WriteLine("Category deleted!");
                }
                else
                {
                    Console.WriteLine("Category not found!");
                }

                break;
            }

        case "4":
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine()!);

                var category = db.Categories.Find(id);

                if (category != null)
                {
                    Console.WriteLine($"{category.Id} | {category.Name}");
                }
                else
                {
                    Console.WriteLine("Category not found!");
                }

                break;
            }

        case "5":
            {
                Console.Write("Name: ");
                string? name = Console.ReadLine();

                var categories = db.Categories
                    .Where(x => x.Name.Contains(name!))
                    .ToList();

                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.Id} | {category.Name}");
                }

                break;
            }

        case "6":
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine()!);

                var category = db.Categories.Find(id);

                if (category != null)
                {
                    Console.Write("New name: ");
                    category.Name = Console.ReadLine()!;

                    Console.Write("New description: ");
                    category.Description = Console.ReadLine()!;

                    db.SaveChanges();

                    Console.WriteLine("Category updated!");
                }
                else
                {
                    Console.WriteLine("Category not found!");
                }

                break;
            }

        case "7":
            {
                Console.Write("Name: ");
                string? name = Console.ReadLine();

                Console.Write("Description: ");
                string? description = Console.ReadLine();

                Console.Write("Price: ");
                decimal price = decimal.Parse(Console.ReadLine()!);

                Console.Write("Category ID: ");
                int categoryId = int.Parse(Console.ReadLine()!);

                var category = db.Categories.Find(categoryId);

                if (category == null)
                {
                    Console.WriteLine("Category not found!");
                    break;
                }

                Product product = new()
                {
                    Name = name!,
                    Description = description!,
                    Price = price,
                    IsDeleted = false,
                    CategoryId = categoryId
                };

                db.Products.Add(product);
                db.SaveChanges();

                Console.WriteLine("Product created!");
                break;
            }

        case "8":
            {
                Console.Write("Product ID: ");
                int id = int.Parse(Console.ReadLine()!);

                var product = db.Products.Find(id);

                if (product != null)
                {
                    Console.Write("New name: ");
                    product.Name = Console.ReadLine()!;

                    Console.Write("New description: ");
                    product.Description = Console.ReadLine()!;

                    Console.Write("New price: ");
                    product.Price = decimal.Parse(Console.ReadLine()!);

                    db.SaveChanges();

                    Console.WriteLine("Product updated!");
                }
                else
                {
                    Console.WriteLine("Product not found!");
                }

                break;
            }

        case "9":
            {
                Console.Write("Product ID: ");
                int id = int.Parse(Console.ReadLine()!);

                var product = db.Products.FirstOrDefault(x => x.Id == id);

                if (product != null)
                {
                    product.IsDeleted = true;
                    db.SaveChanges();

                    Console.WriteLine("Product deleted (soft delete)!");
                }
                else
                {
                    Console.WriteLine("Product not found!");
                }

                break;
            }

        case "10":
            {
                var categories = db.Categories.ToList();

                foreach (var category in categories)
                {
                    Console.WriteLine($"\nCATEGORY: {category.Name}");

                    var products = db.Products
                        .Where(x => x.CategoryId == category.Id && x.IsDeleted == false)
                        .ToList();

                    foreach (var product in products)
                    {
                        Console.WriteLine($"{product.Name} | {product.Price}");
                    }
                }

                break;
            }

        case "11":
            {
                var categories = db.Categories.ToList();

                foreach (var category in categories)
                {
                    int count = db.Products
                        .Where(x => x.CategoryId == category.Id && x.IsDeleted == false)
                        .Count();

                    Console.WriteLine($"{category.Name} | {count} products");
                }

                break;
            }

        case "12":
            {
                var categories = db.Categories.ToList();

                foreach (var category in categories)
                {
                    var product = db.Products
                        .Where(x => x.CategoryId == category.Id && x.IsDeleted == false)
                        .OrderBy(x => x.Price)
                        .FirstOrDefault();

                    if (product != null)
                    {
                        Console.WriteLine($"{category.Name} | {product.Name} | {product.Price}");
                    }
                }

                break;
            }

        case "13":
            {
                var categories = db.Categories.ToList();

                foreach (var category in categories)
                {
                    var products = db.Products
                        .Where(x => x.CategoryId == category.Id && x.IsDeleted == false);

                    if (products.Any())
                    {
                        decimal avg = products.Average(x => x.Price);

                        Console.WriteLine($"{category.Name} | Average price: {avg}");
                    }
                }

                break;
            }

        case "14":
            {
                var categories = db.Categories.ToList();

                foreach (var category in categories)
                {
                    Console.WriteLine($"\nCATEGORY: {category.Name}");

                    var products = db.Products
                        .Where(x => x.CategoryId == category.Id && x.IsDeleted == true)
                        .ToList();

                    if (products.Count == 0)
                    {
                        Console.WriteLine("No deleted products");
                    }

                    foreach (var product in products)
                    {
                        Console.WriteLine($"{product.Id} | {product.Name} | {product.Price}");
                    }
                }

                break;
            }

        case "0":
            {
                isRunning = false;
                break;
            }
    }
}