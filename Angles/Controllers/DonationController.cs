// d:\Learning\Projects\Abanoub Mories Project\BackEnd\Angles\Angles\Controllers\DonationController.cs
using Angles.BL.DTOs;
using Angles.BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Angles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonationService _donationService;

        public DonationController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDonation([FromBody] DonationDto donationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            var result = await _donationService.CreateDonationAsync(userId, donationDto);
            if (result)
                return Ok(new { message = "Donation submitted successfully." });

            return StatusCode(500, "An error occurred while processing your donation.");
        }
    }
}