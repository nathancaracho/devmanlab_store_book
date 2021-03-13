using DevMan.BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DevMan.BookStore.Infrastructure.Mapper
{
    public class CategoryMapper
    {
        public static void Map(ModelBuilder modelBuilder) =>
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