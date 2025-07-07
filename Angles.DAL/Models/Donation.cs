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
        //transaction number , service number , donation amount 
        public double Amount { get; set; }
        public Guid TransactionNumber { get; set; } = Guid.NewGuid();
        public string ServiceNumber { get; set; } = "5462010038124579";

        // Navigation property
        public User User { get; set; }
    }
}