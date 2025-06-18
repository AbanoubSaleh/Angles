using System.ComponentModel.DataAnnotations;

namespace Angles.BL.DTOs
{
    public class SignUpDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression(@"^[0-9]{10,15}$", ErrorMessage = "Phone number must be between 10 and 15 digits")]
        public string Phone { get; set; }
        
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", 
            ErrorMessage = "Password must be at least 8 characters and contain uppercase, lowercase, number and special character")]
        public string Password { get; set; }
        
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        public bool AcceptTerms { get; set; }
    }
}