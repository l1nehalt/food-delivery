using CatalogService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Data.Configurations;

public class ProductsConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .HasOne(p => p.Restaurant)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.RestaurantId);

        builder.HasData(
            new Product
            {
                Id = Guid.Parse("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
                Name = "Маргарита",
                Description = "Томаты, моцарелла, базилик",
                Price = 450,
                IsAvailable = true,
                CategoryId = Guid.Parse("de305d54-75b4-431b-adb2-eb6b9e546013"),
                RestaurantId = Guid.Parse("a1b2c3d4-e5f6-7a8b-9c0d-e1f2a3b4c5d6")
            },
            new Product
            {
                Id = Guid.Parse("88e0b674-135d-495c-9c0e-4366667520e1"),
                Name = "Пепперони",
                Description = "Острые колбаски, много сыра",
                Price = 550,
                IsAvailable = true,
                CategoryId = Guid.Parse("de305d54-75b4-431b-adb2-eb6b9e546013"),
                RestaurantId = Guid.Parse("a1b2c3d4-e5f6-7a8b-9c0d-e1f2a3b4c5d6")
            },
            new Product
            {
                Id = Guid.Parse("55d28b93-135d-495c-9c0e-111122223333"),
                Name = "Кока-кола",
                Description = "0.5л в бутылке",
                Price = 120,
                IsAvailable = true,
                CategoryId = Guid.Parse("f2a3b4c5-d6e7-4890-a1b2-c3d4e5f6a7b8"),
                RestaurantId = Guid.Parse("a1b2c3d4-e5f6-7a8b-9c0d-e1f2a3b4c5d6")
            },
            new Product
            {
                Id = Guid.Parse("7a56976a-5494-4360-9149-14a004b0451e"),
                Name = "Филадельфия",
                Description = "Лосось, сливочный сыр, огурец",
                Price = 480,
                IsAvailable = true,
                CategoryId = Guid.Parse("11111111-2222-3333-4444-555555555555"),
                RestaurantId = Guid.Parse("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e")
            },
            new Product
            {
                Id = Guid.Parse("33334444-5555-6666-7777-888899990000"),
                Name = "Канада Ролл",
                Description = "Угорь, авокадо, соус унаги",
                Price = 620,
                IsAvailable = true,
                CategoryId = Guid.Parse("22222222-3333-4444-5555-666666666666"),
                RestaurantId = Guid.Parse("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e")
            },
            new Product
            {
                Id = Guid.Parse("d111d222-d333-d444-d555-d666d777d888"),
                Name = "Стейк Рибай",
                Description = "Мраморная говядина (прожарка Medium)",
                Price = 1450,
                IsAvailable = true,
                CategoryId = Guid.Parse("33333333-4444-5555-6666-777777777777"),
                RestaurantId = Guid.Parse("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a")
            },
            new Product
            {
                Id = Guid.Parse("e111e222-e333-e444-e555-e666e777e888"),
                Name = "Овощи Гриль",
                Description = "Баклажан, перец, кабачок",
                Price = 320,
                IsAvailable = true,
                CategoryId = Guid.Parse("44444444-5555-6666-7777-888888888888"),
                RestaurantId = Guid.Parse("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a")
            }
        );
    }
}