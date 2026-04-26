using CatalogService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Data.Configurations;

public class RestaurantsConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Categories);
        builder.HasMany(x => x.Products);

        builder.HasData(
            new Restaurant
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7a8b-9c0d-e1f2a3b4c5d6"),
                Name = "Папа Пицца",
                Address = "ул. Ленина, 10",
                IsActive = true
            },
            new Restaurant
            {
                Id = Guid.Parse("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e"),
                Name = "Токио Хаус",
                Address = "пр. Мира, 25",
                IsActive = true
            },
            new Restaurant
            {
                Id = Guid.Parse("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a"),
                Name = "Мясной Цех",
                Address = "ул. Кузнечная, 12",
                IsActive = true
            }
        );
    }
}