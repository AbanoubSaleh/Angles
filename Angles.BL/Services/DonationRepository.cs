using Angles.DAL.Data;
using Angles.DAL.Models;

namespace Angles.BL.Services;

public class DonationRepository : IDonationRepository
{
    private readonly AnglesDbContext _context;

    public DonationRepository(AnglesDbContext context)
    {
        _context = context;
    }

    public async Task<Donation> CreateAsync(Donation donation)
    {
        _context.Donations.Add(donation);
        await _context.SaveChangesAsync();
        return donation;
    }
}

