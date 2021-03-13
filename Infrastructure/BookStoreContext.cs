using DevMan.BookStore.Domain.Models;
using DevMan.BookStore.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace DevMan.BookStore.Infrastructure
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CategoryMapper.Map(modelBuilder);
        }
    }
}