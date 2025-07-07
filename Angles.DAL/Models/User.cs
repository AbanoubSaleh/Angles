using Microsoft.AspNetCore.Identity;

namespace Angles.DAL.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool AcceptedTerms { get; set; }

        public IEnumerable<Donation> Donations { get; set; } = new List<Donation>();
        public IEnumerable<Message> Messages { get; set; } = new List<Message>();
    }
}