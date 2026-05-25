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

                Product product = new()
                {
                    Name = name!,
                    Description = description!,
                    Price = price
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

        case "0":
            {
                isRunning = false;
                break;
            }
    }
}