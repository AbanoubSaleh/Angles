using Angles.DAL.Models;

namespace Angles.BL.Services;

public interface IDonationRepository
{
    Task<Donation> CreateAsync(Donation donation);
}
