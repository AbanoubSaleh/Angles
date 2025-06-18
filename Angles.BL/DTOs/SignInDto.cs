using System.ComponentModel.DataAnnotations;

namespace Angles.BL.DTOs
{
    public class SignInDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}