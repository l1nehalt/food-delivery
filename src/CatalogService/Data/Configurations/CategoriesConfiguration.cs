using CatalogService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Data.Configurations;

public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Restaurant)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.RestaurantId);

        builder.HasData(
            new Category
            {
                Id = Guid.Parse("de305d54-75b4-431b-adb2-eb6b9e546013"),
                Name = "Пицца",
                RestaurantId = Guid.Parse("a1b2c3d4-e5f6-7a8b-9c0d-e1f2a3b4c5d6")
            },
            new Category
            {
                Id = Guid.Parse("f2a3b4c5-d6e7-4890-a1b2-c3d4e5f6a7b8"),
                Name = "Напитки",
                RestaurantId = Guid.Parse("a1b2c3d4-e5f6-7a8b-9c0d-e1f2a3b4c5d6")
            },
            new Category
            {
                Id = Guid.Parse("11111111-2222-3333-4444-555555555555"),
                Name = "Суши",
                RestaurantId = Guid.Parse("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e")
            },
            new Category
            {
                Id = Guid.Parse("22222222-3333-4444-5555-666666666666"),
                Name = "Роллы",
                RestaurantId = Guid.Parse("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e")
            },
            new Category
            {
                Id = Guid.Parse("33333333-4444-5555-6666-777777777777"),
                Name = "Стейки",
                RestaurantId = Guid.Parse("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a")
            },
            new Category
            {
                Id = Guid.Parse("44444444-5555-6666-7777-888888888888"),
                Name = "Гриль",
                RestaurantId = Guid.Parse("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a")
            }
        );
    }
}