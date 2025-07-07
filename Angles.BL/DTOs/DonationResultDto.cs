using Angles.DAL.Models;

namespace Angles.BL.DTOs;

public class DonationResultDto
{
    public string FullName { get; set; }
    public string AccountNumber { get; set; }
    public string ProviderName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
    public string Notes { get; set; }
    public double Amount { get; set; } = 0;

    public static DonationResultDto? MapfromEntity(Donation donation)
    {
        if (donation == null) return null;
        return new DonationResultDto
        {
            FullName = donation.FullName,
            AccountNumber = donation.AccountNumber,
            ProviderName = donation.ProviderName,
            Phone = donation.Phone,
            Email = donation.Email,
            Country = donation.Country,
            Notes = donation.Notes,
            Amount = donation.Amount
        };
    }
}
