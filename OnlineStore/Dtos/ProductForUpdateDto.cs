using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.ValidationAttributes;

namespace OnlineStore.Dtos
{
  
    public class ProductForUpdateDto : ProductForManipulationDto
    {
  
        [Required(ErrorMessage = "Must Update")]
        [MaxLength(1500)]
        public override string Description { get; set; }

    }
}
