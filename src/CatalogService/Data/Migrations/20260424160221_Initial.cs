using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CatalogService.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7a8b-9c0d-e1f2a3b4c5d6"), "ул. Ленина, 10", true, "Папа Пицца" },
                    { new Guid("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e"), "пр. Мира, 25", true, "Токио Хаус" },
                    { new Guid("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a"), "ул. Кузнечная, 12", true, "Мясной Цех" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "RestaurantId" },
                values: new object[,]
                {
                    { new Guid("11111111-2222-3333-4444-555555555555"), "Суши", new Guid("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e") },
                    { new Guid("22222222-3333-4444-5555-666666666666"), "Роллы", new Guid("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e") },
                    { new Guid("33333333-4444-5555-6666-777777777777"), "Стейки", new Guid("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a") },
                    { new Guid("44444444-5555-6666-7777-888888888888"), "Гриль", new Guid("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a") },
                    { new Guid("de305d54-75b4-431b-adb2-eb6b9e546013"), "Пицца", new Guid("a1b2c3d4-e5f6-7a8b-9c0d-e1f2a3b4c5d6") },
                    { new Guid("f2a3b4c5-d6e7-4890-a1b2-c3d4e5f6a7b8"), "Напитки", new Guid("a1b2c3d4-e5f6-7a8b-9c0d-e1f2a3b4c5d6") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "IsAvailable", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { new Guid("33334444-5555-6666-7777-888899990000"), new Guid("22222222-3333-4444-5555-666666666666"), "Угорь, авокадо, соус унаги", true, "Канада Ролл", 620m, new Guid("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e") },
                    { new Guid("55d28b93-135d-495c-9c0e-111122223333"), new Guid("f2a3b4c5-d6e7-4890-a1b2-c3d4e5f6a7b8"), "0.5л в бутылке", true, "Кока-кола", 120m, new Guid("a1b2c3d4-e5f6-7a8b-9c0d-e1f2a3b4c5d6") },
                    { new Guid("7a56976a-5494-4360-9149-14a004b0451e"), new Guid("11111111-2222-3333-4444-555555555555"), "Лосось, сливочный сыр, огурец", true, "Филадельфия", 480m, new Guid("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e") },
                    { new Guid("88e0b674-135d-495c-9c0e-4366667520e1"), new Guid("de305d54-75b4-431b-adb2-eb6b9e546013"), "Острые колбаски, много сыра", true, "Пепперони", 550m, new Guid("a1b2c3d4-e5f6-7a8b-9c0d-e1f2a3b4c5d6") },
                    { new Guid("d111d222-d333-d444-d555-d666d777d888"), new Guid("33333333-4444-5555-6666-777777777777"), "Мраморная говядина (прожарка Medium)", true, "Стейк Рибай", 1450m, new Guid("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a") },
                    { new Guid("e111e222-e333-e444-e555-e666e777e888"), new Guid("44444444-5555-6666-7777-888888888888"), "Баклажан, перец, кабачок", true, "Овощи Гриль", 320m, new Guid("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a") },
                    { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), new Guid("de305d54-75b4-431b-adb2-eb6b9e546013"), "Томаты, моцарелла, базилик", true, "Маргарита", 450m, new Guid("a1b2c3d4-e5f6-7a8b-9c0d-e1f2a3b4c5d6") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RestaurantId",
                table: "Categories",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RestaurantId",
                table: "Products",
                column: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
