using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Dtos;

namespace OnlineStore.ValidationAttributes
{
    public class ProductTitleMustBeDifferentFromDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var productDto = (ProductForManipulationDto)validationContext.ObjectInstance;
            if (productDto.Title == productDto.Description)
            {
                return new ValidationResult("Title must be different from description", new[] { "ProductForCreationDto" });
            }
            return ValidationResult.Success;
        }
    }
}
