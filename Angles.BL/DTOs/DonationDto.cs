using Angles.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Angles.BL.DTOs;

public class DonationDto
{
    [Required]
    public PaymentMethod PaymentMethod { get; set; }

    [Required]
    public string FullName { get; set; }

    public string AccountNumber { get; set; }

    public string ProviderName { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string Country { get; set; }

    public string Notes { get; set; }
    [Required]
    public string UserId { get; set; }
}