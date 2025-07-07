using Microsoft.AspNetCore.Identity;
using Angles.BL.DTOs;
using Angles.DAL.Models;

namespace Angles.BL.Services;

public class DonationService : IDonationService
{
    private readonly IDonationRepository _donationRepository;
    private readonly UserManager<User> _userManager;

    public DonationService(IDonationRepository donationRepository, UserManager<User> userManager)
    {
        _donationRepository = donationRepository;
        _userManager = userManager;
    }

    public async Task<bool> CreateDonationAsync(string userId, DonationDto donationDto)
    {
        // Validate user exists
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return false;
        }

        var donation = new Donation
        {
            UserId = userId,
            PaymentMethod = donationDto.PaymentMethod,
            FullName = donationDto.FullName,
            AccountNumber = donationDto.AccountNumber,
            ProviderName = donationDto.ProviderName,
            Phone = donationDto.Phone,
            Email = donationDto.Email,
            Country = donationDto.Country,
            Notes = donationDto.Notes,
            Amount = donationDto.Amount > 0 ? donationDto.Amount : 0, // Ensure amount is not negative
        };

        await _donationRepository.CreateAsync(donation);
        return true;
    }
}