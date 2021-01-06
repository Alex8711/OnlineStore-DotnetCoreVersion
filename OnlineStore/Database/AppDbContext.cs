using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OnlineStore.Database
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<LineItem> LineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           var productJsonData =  File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+@"/Database/productMockData.json");
           IList<Product> products = JsonConvert.DeserializeObject<IList<Product>>(productJsonData);
           modelBuilder.Entity<Product>().HasData(products);

           var productPicturesJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Database/productPicturesMockData.json");
           IList<ProductPicture> productPictures = JsonConvert.DeserializeObject<IList<ProductPicture>>(productPicturesJsonData);
           modelBuilder.Entity<ProductPicture>().HasData(productPictures);

           // initial user and role data seeding
           
           //1. update user and role's foreign key
           modelBuilder.Entity<ApplicationUser>(u =>
               u.HasMany(x => x.UserRoles)
                   .WithOne().HasForeignKey(ur => ur.UserId).IsRequired()
           );
           //2. add admin role
           var adminRoleId = "308660dc-ae51-480f-824d-7dca6714c3e2"; 
           modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole()
               {
                  Id= adminRoleId,
                  Name = "Admin",
                  NormalizedName = "Admin".ToUpper()
               }
           );
           //3. add user
           var adminUserId = "90184155-dee0-40c9-bb1e-b5ed07afc04e";
           ApplicationUser adminUser = new ApplicationUser
           {
               Id = adminUserId,
               UserName = "admin@fakexiecheng.com",
               NormalizedUserName = "admin@fakexiecheng.com".ToUpper(),
               Email = "admin@fakexiecheng.com",
               NormalizedEmail = "admin@fakexiecheng.com".ToUpper(),
               TwoFactorEnabled = false,
               EmailConfirmed = true,
               PhoneNumber = "123456789",
               PhoneNumberConfirmed = false
           };
           PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
           adminUser.PasswordHash = ph.HashPassword(adminUser, "Fake123$");
           modelBuilder.Entity<ApplicationUser>().HasData(adminUser);
           //4. add admin role to the user
           modelBuilder.Entity<IdentityUserRole<string>>()
               .HasData(new IdentityUserRole<string>() 
               {
                   RoleId = adminRoleId,
                   UserId = adminUserId
               });
           base.OnModelCreating(modelBuilder);
        }
    }
}
