using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required] 
        [Compare(nameof(Password),ErrorMessage = "The password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
