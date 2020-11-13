using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using Newtonsoft.Json;

namespace OnlineStore.Database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           var productJsonData =  File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+@"/Database/productMockData.json");
           IList<Product> products = JsonConvert.DeserializeObject<IList<Product>>(productJsonData);
           modelBuilder.Entity<Product>().HasData(products);

           var productPicturesJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Database/productPicturesMockData.json");
           IList<ProductPicture> productPictures = JsonConvert.DeserializeObject<IList<ProductPicture>>(productPicturesJsonData);
           modelBuilder.Entity<ProductPicture>().HasData(productPictures);

            base.OnModelCreating(modelBuilder);
        }
    }
}
