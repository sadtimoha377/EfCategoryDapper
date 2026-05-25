using EfOne.Models;
using Microsoft.EntityFrameworkCore;

namespace EfOne.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=EfCategoryDb;Trusted_Connection=True;"
            );
        }
    }
}