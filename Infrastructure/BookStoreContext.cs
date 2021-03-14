using DevMan.BookStore.Domain.Models;
using DevMan.BookStore.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace DevMan.BookStore.Infrastructure
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CategoryMapper.Map(modelBuilder);
            AuthorMapper.Map(modelBuilder);
            BookMapper.Map(modelBuilder);
        }
    }
}