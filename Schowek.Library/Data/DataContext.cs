using Microsoft.EntityFrameworkCore;

namespace Schowek.Library.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Catalog>? Catalogs { get; set; }
        public DbSet<Item>? Items { get; set; }
    }
}