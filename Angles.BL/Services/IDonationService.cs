using Angles.BL.DTOs;

namespace Angles.BL.Services;

public interface IDonationService
{
    Task<bool> CreateDonationAsync(string userId, DonationDto donationDto);
}
