using Schowek.Library.Models;

namespace SchowekAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Catalog>? Catalogs { get; set; } = null!;
        public DbSet<Item>? Items { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("app.db");
            }
        }
    }
}