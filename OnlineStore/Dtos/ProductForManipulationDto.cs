using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.ValidationAttributes;

namespace OnlineStore.Dtos
{
    [ProductTitleMustBeDifferentFromDescription]
    public abstract class ProductForManipulationDto
    {
        [Required(ErrorMessage = "Title can not be null")]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1500)]
        public virtual string Description { get; set; }

        public string Brand { get; set; }

        public string Category { get; set; }

        public int CountInStock { get; set; }

        public decimal Price { get; set; }
 
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public ICollection<ProductPictureForCreationDto> ProductPictures { get; set; }
            = new List<ProductPictureForCreationDto>();
    }
}
