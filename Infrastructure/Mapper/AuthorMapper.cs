using DevMan.BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DevMan.BookStore.Infrastructure.Mapper
{
    public class AuthorMapper
    {
        public static void Map(ModelBuilder modelBuilder) =>
            modelBuilder.Entity<Author>(author =>
            {
                author
                    .HasKey(a => a.Id);

                author
                    .Property(a => a.Id)
                    .ValueGeneratedOnAdd();

                author
                    .Property(a => a.Birthday)
                    .IsRequired();

                author
                    .Property(a => a.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                author
                    .Ignore(a => a.Age);
            });
    }
}
