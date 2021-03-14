using DevMan.BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DevMan.BookStore.Infrastructure.Mapper
{
    public class BookMapper
    {
        public static void Map(ModelBuilder modelBuilder) =>
            modelBuilder.Entity<Book>(book =>
            {
                book
                    .HasKey(b => b.Id);

                book
                    .Property(b => b.Id)
                    .ValueGeneratedOnAdd();

                book
                    .Property(b => b.Title)
                    .HasMaxLength(100)
                    .IsRequired();

                book
                    .Property(b => b.BriefDescription)
                    .HasMaxLength(200)
                    .IsRequired();

                book
                    .HasMany(b => b.Authors)
                    .WithMany(c => c.Books);

                book
                    .HasMany(b => b.Categories)
                    .WithMany(c => c.Books);
            });
    }
}
//https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key