using System.ComponentModel.DataAnnotations;

namespace Angles.BL.DTOs
{
    public class MessageDto
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression(@"^[0-9]{10,15}$", ErrorMessage = "Phone number must be between 10 and 15 digits")]
        public string Phone { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        public string UserId { get; set; }
    }
}