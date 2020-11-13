using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1500, nullable: false),
                    Brand = table.Column<string>(maxLength: 30, nullable: false),
                    Category = table.Column<string>(maxLength: 30, nullable: false),
                    CountInStock = table.Column<int>(nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercentage = table.Column<double>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductPictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(maxLength: 100, nullable: true),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPictures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "CountInStock", "CreateTime", "Description", "DiscountPercentage", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("fb6d4f10-79ed-4aff-a915-4ce29dc9c7e1"), "Apple", "Electronics", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bluetooth technology lets you connect it with compatible devices wirelessly High-quality AAC audio offers immersive listening experience Built-in microphone allows you to take calls while working", 0.90000000000000002, 299.99m, "Airpods Wireless Bluetooth Headphones", null },
                    { new Guid("a1fd0bee-0afc-4586-96c8-f46b7c99d2a0"), "Apple", "Electronics", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introducing the iPhone 11 Pro. A transformative triple-camera system that adds tons of capability without complexity. An unprecedented leap in battery life", 0.98999999999999999, 899.99m, "iPhone 11 Pro 256GB Memory", null },
                    { new Guid("88cf89b9-e4b5-4b42-a5bf-622bd3039601"), "Cannon", "Electronics", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Characterized by versatile imaging specs, the Canon EOS 80D further clarifies itself using a pair of robust focusing systems and an intuitive design", 0.5, 6999.9m, "Cannon EOS 80D DSLR Camera", null },
                    { new Guid("2430bf64-fd56-460c-8b75-da0a1d1cd74c"), "Sony", "Electronics", 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The ultimate home entertainment center starts with PlayStation. Whether you are into gaming, HD movies, television, music", 0.90000000000000002, 399.8m, "Sony Playstation 4 Pro White Version", null },
                    { new Guid("39996f34-013c-4fc6-b1b3-0c1036c47169"), "Logitech", "Electronics", 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Get a better handle on your games with this Logitech LIGHTSYNC gaming mouse. The six programmable buttons allow customization for a smooth playing experience", null, 199.8m, "Logitech G-Series Gaming Mouse", null },
                    { new Guid("39996f34-013c-4fc6-b1b3-0c1036c47110"), "Amazon", "Electronics", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meet Echo Dot - Our most popular smart speaker with a fabric design. It is our most compact smart speaker that fits perfectly into small space", null, 99.99m, "Amazon Echo Dot 3rd Generation", null },
                    { new Guid("39996f34-013c-4fc6-b1b3-0c1036c47111"), "Linksys", "Electronics", 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An interconnected series of nodes that ensures complete signal coverage to all your devices", 0.90000000000000002, 299.8m, "Velop Whole Home Mesh Wifi", null },
                    { new Guid("39996f34-013c-4fc6-b1b3-0c1036c47112"), "Sony", "Electronics", 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Experience lightning-fast loading with an ultra-high speed SSD, deeper immersion with support for haptic feedback, adaptive triggers and 3D Audio, and an all-new generation of incredible PlayStation games", null, 499.8m, "Sony Playstation 5", null },
                    { new Guid("39996f34-013c-4fc6-b1b3-0c1036c47114"), "Corsair", "Electronics", 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Immerse yourself in the action with the Corsair VOID RGB Elite wireless, with custom-tuned 50mm neodymium audio drivers delivering 7.1 surround sound on PC", 0.90000000000000002, 129.8m, "Corsair Gaming Void RGB Elite Wireless Premium Gaming Headset", null },
                    { new Guid("39996f34-013c-4fc6-b1b3-0c1036c47115"), "Sony", "Electronics", 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Step into a new world of 4K HDR colour, contrast, and clarity. See beautiful pictures, rich with real world detail and texture, powered by our 4K HDR processor X1", 0.98999999999999999, 1455.8m, "Sony X800H 65-inch 4K HDR LED Android Smart TV", null },
                    { new Guid("39996f34-013c-4fc6-b1b3-0c1036c47116"), "EVGA", "Electronics", 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EVGA GeForce RTX 3080 FTW3 ULTRA GAMING, 10G-P5-3897-KR, 10GB GDDR6X, iCX3 Technology, ARGB LED, Metal Backplate.", null, 2500.8m, "EVGA GeForce RTX 3080 Ultra Gaming", null },
                    { new Guid("39996f34-013c-4fc6-b1b3-0c1036c47117"), "Kingston", "Electronics", 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The HyperX Alloy Origins is a compact, sturdy keyboard featuring custom HyperX mechanical switches designed to give gamers the best blend of style, performance, and reliability", 0.90000000000000002, 154.99m, "HyperX Alloy Origins Mechanical Gaming Keyboard", null },
                    { new Guid("39996f34-013c-4fc6-b1b3-0c1036c47118"), "Dell", "Electronics", 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A 27 inch IPS gaming monitor with a blazing 240Hz refresh rate and true 1ms response time. Featuring AMD FreeSync technology for effortlessly smooth gaming", 0.90000000000000002, 529.99m, "New Alienware 27 Gaming Monitor - AW2720HF", null },
                    { new Guid("39996f34-013c-4fc6-b1b3-0c1036c47119"), "MicroSoft", "Electronics", 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "THE FASTEST,MOST POWERFUL XBOX EVER", null, 499.8m, "Xbox Series X", null }
                });

            migrationBuilder.InsertData(
                table: "ProductPictures",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { 1, new Guid("fb6d4f10-79ed-4aff-a915-4ce29dc9c7e1"), "../../assets/images/airpods.jpg" },
                    { 2, new Guid("a1fd0bee-0afc-4586-96c8-f46b7c99d2a0"), "../../assets/images/phone.jpg" },
                    { 3, new Guid("88cf89b9-e4b5-4b42-a5bf-622bd3039601"), "../../assets/images/camera.jpg" },
                    { 4, new Guid("2430bf64-fd56-460c-8b75-da0a1d1cd74c"), "../../assets/images/playstation.jpg" },
                    { 5, new Guid("39996f34-013c-4fc6-b1b3-0c1036c47169"), "../../assets/images/mouse.jpg" },
                    { 6, new Guid("39996f34-013c-4fc6-b1b3-0c1036c47110"), "../../assets/images/alexa.jpg" },
                    { 7, new Guid("39996f34-013c-4fc6-b1b3-0c1036c47111"), "../../assets/images/velopMesh.jpg" },
                    { 8, new Guid("39996f34-013c-4fc6-b1b3-0c1036c47112"), "../../assets/images/ps5.jpg" },
                    { 10, new Guid("39996f34-013c-4fc6-b1b3-0c1036c47114"), "../../assets/images/headset.jpg" },
                    { 11, new Guid("39996f34-013c-4fc6-b1b3-0c1036c47115"), "../../assets/images/sonyTV.jpg" },
                    { 12, new Guid("39996f34-013c-4fc6-b1b3-0c1036c47116"), "../../assets/images/rtx3080.jpg" },
                    { 13, new Guid("39996f34-013c-4fc6-b1b3-0c1036c47117"), "../../assets/images/hyperxKeyboard.jpg" },
                    { 14, new Guid("39996f34-013c-4fc6-b1b3-0c1036c47118"), "../../assets/images/alienwareMonitor.jpg" },
                    { 15, new Guid("39996f34-013c-4fc6-b1b3-0c1036c47119"), "../../assets/images/xbox.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictures_ProductId",
                table: "ProductPictures",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPictures");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
