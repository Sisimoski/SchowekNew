using Microsoft.EntityFrameworkCore;
using Schowek.Library.Models;

namespace Schowek.Library.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Catalog>? Catalogs { get; set; } = null!;
        public DbSet<Item>? Items { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=./Data/app.db");
            }
        }
    }
}