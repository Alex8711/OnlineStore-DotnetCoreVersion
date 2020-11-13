using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1500)]
        public string Description { get; set; }
        [Required]
        [MaxLength(30)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(30)]
        public string Category { get; set; }
        
        [Required]
        [Range(0,int.MaxValue)]
        public int CountInStock { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0,(double)decimal.MaxValue)]
        public decimal OriginalPrice { get; set; }
        [Range(0.0,1.0)]
        public double? DiscountPercentage { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public ICollection<ProductPicture> ProductPictures { get; set; }=new List<ProductPicture>();

    }
}
