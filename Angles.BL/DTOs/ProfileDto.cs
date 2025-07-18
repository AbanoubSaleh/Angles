﻿namespace Angles.BL.DTOs;

public class ProfileDto
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public IEnumerable<DonationResultDto?> Donations { get; set; } = new List<DonationResultDto>();

}
