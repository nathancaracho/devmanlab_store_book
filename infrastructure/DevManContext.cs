using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DevMan.BookStore.infrastructure
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(category =>
            {
                category
                    .HasKey(c => c.Id);

                category
                    .Property(c => c.Id)
                    .ValueGeneratedOnAdd();

                category
                    .Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                category
                    .Property(c => c.Description)
                    .IsRequired()
                    .HasMaxLength(400);
            }
            );
        }
    }
}