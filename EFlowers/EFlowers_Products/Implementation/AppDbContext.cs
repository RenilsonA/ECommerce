using Microsoft.EntityFrameworkCore;

namespace EFlowers_Products.Implementation
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().
               Property(c => c.Name).
                 HasMaxLength(100).
                   IsRequired();

            modelBuilder.Entity<Product>().
              Property(c => c.Description).
                   HasMaxLength(255).
                       IsRequired();

            modelBuilder.Entity<Product>().
              Property(c => c.ImgURL).
                  HasMaxLength(255).
                      IsRequired();

            modelBuilder.Entity<Product>().
               Property(c => c.Price).
                 HasPrecision(12, 2);
        }
    }
}
