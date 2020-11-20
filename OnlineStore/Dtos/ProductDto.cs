using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Dtos
{
    public class ProductDto
    {
    
        public Guid Id { get; set; }
       
        public string Title { get; set; }
    
        public string Description { get; set; }
    
        public string Brand { get; set; }
    
        public string Category { get; set; }

        public int CountInStock { get; set; }
        public decimal Price { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        // the property name should be same as the property in the Product!!
        public ICollection<ProductPictureDto> ProductPictures { get; set; }
    }
}
