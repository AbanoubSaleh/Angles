// d:\Learning\Projects\Abanoub Mories Project\BackEnd\Angles\Angles.BL\Services\DonationService.cs
using Angles.BL.DTOs;
using Angles.DAL.Models;

namespace Angles.BL.Services;

public class DonationService : IDonationService
{
    private readonly IDonationRepository _donationRepository;

    public DonationService(IDonationRepository donationRepository)
    {
        _donationRepository = donationRepository;
    }

    public async Task<bool> CreateDonationAsync(string userId, DonationDto donationDto)
    {
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
            Notes = donationDto.Notes
        };

        await _donationRepository.CreateAsync(donation);
        return true;
    }
}