﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineStore.Database;

namespace OnlineStore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210105035902_ApplicationUserMigration")]
    partial class ApplicationUserMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "308660dc-ae51-480f-824d-7dca6714c3e2",
                            ConcurrencyStamp = "3d569176-95a7-43fe-a006-989ce5de410d",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "90184155-dee0-40c9-bb1e-b5ed07afc04e",
                            RoleId = "308660dc-ae51-480f-824d-7dca6714c3e2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OnlineStore.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "90184155-dee0-40c9-bb1e-b5ed07afc04e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "82ab9ced-68a5-4282-b6b0-4cd034486a56",
                            Email = "admin@fakexiecheng.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@FAKEXIECHENG.COM",
                            NormalizedUserName = "ADMIN@FAKEXIECHENG.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEPOrwTN/vsd5WtWa2MGUmZM5nsjWQza+25xl72NZperAZlNH9Wfg/INx5lBq7Uli+A==",
                            PhoneNumber = "123456789",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "11bcd702-e87f-4813-8e9f-667e46be5a19",
                            TwoFactorEnabled = false,
                            UserName = "admin@fakexiecheng.com"
                        });
                });

            modelBuilder.Entity("OnlineStore.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<int>("CountInStock")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(1500) CHARACTER SET utf8mb4")
                        .HasMaxLength(1500);

                    b.Property<double?>("DiscountPercentage")
                        .HasColumnType("double");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fb6d4f10-79ed-4aff-a915-4ce29dc9c7e1"),
                            Brand = "Apple",
                            Category = "Electronics",
                            CountInStock = 10,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Bluetooth technology lets you connect it with compatible devices wirelessly High-quality AAC audio offers immersive listening experience Built-in microphone allows you to take calls while working",
                            DiscountPercentage = 0.90000000000000002,
                            OriginalPrice = 299.99m,
                            Title = "Airpods Wireless Bluetooth Headphones"
                        },
                        new
                        {
                            Id = new Guid("a1fd0bee-0afc-4586-96c8-f46b7c99d2a0"),
                            Brand = "Apple",
                            Category = "Electronics",
                            CountInStock = 10,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Introducing the iPhone 11 Pro. A transformative triple-camera system that adds tons of capability without complexity. An unprecedented leap in battery life",
                            DiscountPercentage = 0.98999999999999999,
                            OriginalPrice = 899.99m,
                            Title = "iPhone 11 Pro 256GB Memory"
                        },
                        new
                        {
                            Id = new Guid("88cf89b9-e4b5-4b42-a5bf-622bd3039601"),
                            Brand = "Cannon",
                            Category = "Electronics",
                            CountInStock = 5,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Characterized by versatile imaging specs, the Canon EOS 80D further clarifies itself using a pair of robust focusing systems and an intuitive design",
                            DiscountPercentage = 0.5,
                            OriginalPrice = 6999.9m,
                            Title = "Cannon EOS 80D DSLR Camera"
                        },
                        new
                        {
                            Id = new Guid("2430bf64-fd56-460c-8b75-da0a1d1cd74c"),
                            Brand = "Sony",
                            Category = "Electronics",
                            CountInStock = 11,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The ultimate home entertainment center starts with PlayStation. Whether you are into gaming, HD movies, television, music",
                            DiscountPercentage = 0.90000000000000002,
                            OriginalPrice = 399.8m,
                            Title = "Sony Playstation 4 Pro White Version"
                        },
                        new
                        {
                            Id = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47169"),
                            Brand = "Logitech",
                            Category = "Electronics",
                            CountInStock = 7,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Get a better handle on your games with this Logitech LIGHTSYNC gaming mouse. The six programmable buttons allow customization for a smooth playing experience",
                            OriginalPrice = 199.8m,
                            Title = "Logitech G-Series Gaming Mouse"
                        },
                        new
                        {
                            Id = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47110"),
                            Brand = "Amazon",
                            Category = "Electronics",
                            CountInStock = 0,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Meet Echo Dot - Our most popular smart speaker with a fabric design. It is our most compact smart speaker that fits perfectly into small space",
                            OriginalPrice = 99.99m,
                            Title = "Amazon Echo Dot 3rd Generation"
                        },
                        new
                        {
                            Id = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47111"),
                            Brand = "Linksys",
                            Category = "Electronics",
                            CountInStock = 11,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "An interconnected series of nodes that ensures complete signal coverage to all your devices",
                            DiscountPercentage = 0.90000000000000002,
                            OriginalPrice = 299.8m,
                            Title = "Velop Whole Home Mesh Wifi"
                        },
                        new
                        {
                            Id = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47112"),
                            Brand = "Sony",
                            Category = "Electronics",
                            CountInStock = 11,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Experience lightning-fast loading with an ultra-high speed SSD, deeper immersion with support for haptic feedback, adaptive triggers and 3D Audio, and an all-new generation of incredible PlayStation games",
                            OriginalPrice = 499.8m,
                            Title = "Sony Playstation 5"
                        },
                        new
                        {
                            Id = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47114"),
                            Brand = "Corsair",
                            Category = "Electronics",
                            CountInStock = 11,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Immerse yourself in the action with the Corsair VOID RGB Elite wireless, with custom-tuned 50mm neodymium audio drivers delivering 7.1 surround sound on PC",
                            DiscountPercentage = 0.90000000000000002,
                            OriginalPrice = 129.8m,
                            Title = "Corsair Gaming Void RGB Elite Wireless Premium Gaming Headset"
                        },
                        new
                        {
                            Id = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47115"),
                            Brand = "Sony",
                            Category = "Electronics",
                            CountInStock = 11,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Step into a new world of 4K HDR colour, contrast, and clarity. See beautiful pictures, rich with real world detail and texture, powered by our 4K HDR processor X1",
                            DiscountPercentage = 0.98999999999999999,
                            OriginalPrice = 1455.8m,
                            Title = "Sony X800H 65-inch 4K HDR LED Android Smart TV"
                        },
                        new
                        {
                            Id = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47116"),
                            Brand = "EVGA",
                            Category = "Electronics",
                            CountInStock = 11,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "EVGA GeForce RTX 3080 FTW3 ULTRA GAMING, 10G-P5-3897-KR, 10GB GDDR6X, iCX3 Technology, ARGB LED, Metal Backplate.",
                            OriginalPrice = 2500.8m,
                            Title = "EVGA GeForce RTX 3080 Ultra Gaming"
                        },
                        new
                        {
                            Id = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47117"),
                            Brand = "Kingston",
                            Category = "Electronics",
                            CountInStock = 11,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The HyperX Alloy Origins is a compact, sturdy keyboard featuring custom HyperX mechanical switches designed to give gamers the best blend of style, performance, and reliability",
                            DiscountPercentage = 0.90000000000000002,
                            OriginalPrice = 154.99m,
                            Title = "HyperX Alloy Origins Mechanical Gaming Keyboard"
                        },
                        new
                        {
                            Id = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47118"),
                            Brand = "Dell",
                            Category = "Electronics",
                            CountInStock = 11,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A 27 inch IPS gaming monitor with a blazing 240Hz refresh rate and true 1ms response time. Featuring AMD FreeSync technology for effortlessly smooth gaming",
                            DiscountPercentage = 0.90000000000000002,
                            OriginalPrice = 529.99m,
                            Title = "New Alienware 27 Gaming Monitor - AW2720HF"
                        },
                        new
                        {
                            Id = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47119"),
                            Brand = "MicroSoft",
                            Category = "Electronics",
                            CountInStock = 11,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "THE FASTEST,MOST POWERFUL XBOX EVER",
                            OriginalPrice = 499.8m,
                            Title = "Xbox Series X"
                        });
                });

            modelBuilder.Entity("OnlineStore.Models.ProductPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Url")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPictures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = new Guid("fb6d4f10-79ed-4aff-a915-4ce29dc9c7e1"),
                            Url = "../../assets/images/airpods.jpg"
                        },
                        new
                        {
                            Id = 2,
                            ProductId = new Guid("a1fd0bee-0afc-4586-96c8-f46b7c99d2a0"),
                            Url = "../../assets/images/phone.jpg"
                        },
                        new
                        {
                            Id = 3,
                            ProductId = new Guid("88cf89b9-e4b5-4b42-a5bf-622bd3039601"),
                            Url = "../../assets/images/camera.jpg"
                        },
                        new
                        {
                            Id = 4,
                            ProductId = new Guid("2430bf64-fd56-460c-8b75-da0a1d1cd74c"),
                            Url = "../../assets/images/playstation.jpg"
                        },
                        new
                        {
                            Id = 5,
                            ProductId = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47169"),
                            Url = "../../assets/images/mouse.jpg"
                        },
                        new
                        {
                            Id = 6,
                            ProductId = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47110"),
                            Url = "../../assets/images/alexa.jpg"
                        },
                        new
                        {
                            Id = 7,
                            ProductId = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47111"),
                            Url = "../../assets/images/velopMesh.jpg"
                        },
                        new
                        {
                            Id = 8,
                            ProductId = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47112"),
                            Url = "../../assets/images/ps5.jpg"
                        },
                        new
                        {
                            Id = 10,
                            ProductId = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47114"),
                            Url = "../../assets/images/headset.jpg"
                        },
                        new
                        {
                            Id = 11,
                            ProductId = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47115"),
                            Url = "../../assets/images/sonyTV.jpg"
                        },
                        new
                        {
                            Id = 12,
                            ProductId = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47116"),
                            Url = "../../assets/images/rtx3080.jpg"
                        },
                        new
                        {
                            Id = 13,
                            ProductId = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47117"),
                            Url = "../../assets/images/hyperxKeyboard.jpg"
                        },
                        new
                        {
                            Id = 14,
                            ProductId = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47118"),
                            Url = "../../assets/images/alienwareMonitor.jpg"
                        },
                        new
                        {
                            Id = 15,
                            ProductId = new Guid("39996f34-013c-4fc6-b1b3-0c1036c47119"),
                            Url = "../../assets/images/xbox.jpg"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OnlineStore.Models.ApplicationUser", null)
                        .WithMany("Claims")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("OnlineStore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OnlineStore.Models.ApplicationUser", null)
                        .WithMany("Logins")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("OnlineStore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("OnlineStore.Models.ApplicationUser", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OnlineStore.Models.ApplicationUser", null)
                        .WithMany("Tokens")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("OnlineStore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineStore.Models.ProductPicture", b =>
                {
                    b.HasOne("OnlineStore.Models.Product", "Product")
                        .WithMany("ProductPictures")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
