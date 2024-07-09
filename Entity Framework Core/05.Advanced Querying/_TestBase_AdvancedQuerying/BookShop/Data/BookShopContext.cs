using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using MusicHub.Data;

namespace BookShop.Data
{
    public class BookShopContext : DbContext
    {
        public BookShopContext()
        {

        }

        public BookShopContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new
                {
                    bc.BookId,
                    bc.CategoryId
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
