namespace Angles.DAL.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public string UserId { get; set; }  // FK to User who donated
        public PaymentMethod PaymentMethod { get; set; } 
        public string FullName { get; set; }
        public string AccountNumber { get; set; }
        public string ProviderName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public User User { get; set; }
    }
}