using Microsoft.EntityFrameworkCore;
using Schowek.Shared.Core.Models;

namespace Schowek.Shared.Core.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Catalog>? Catalogs { get; set; }
        public DbSet<Item>? Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=/Users/sisimoski/Documents/Development 👨‍💻/SchowekNew/Schowek.Library/Data/app.db");
            }
        }
    }
}