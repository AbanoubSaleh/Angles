using Angles.BL.DTOs;
using Angles.BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Angles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboardStats()
        {
            var stats = await _adminService.GetDashboardStatsAsync();
            return Ok(stats);
        }

        [HttpGet("donations")]
        public async Task<IActionResult> GetDonations([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var donations = await _adminService.GetAllDonationsAsync(startDate, endDate);
            return Ok(donations);
        }

        [HttpGet("donations/export")]
        public async Task<IActionResult> ExportDonations([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var excelBytes = await _adminService.ExportDonationsToExcelAsync(startDate, endDate);
            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "donations.xlsx");
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromQuery] string? searchTerm)
        {
            var users = await _adminService.GetAllUsersAsync(searchTerm);
            return Ok(users);
        }

        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetUserDetails(string userId)
        {
            var user = await _adminService.GetUserDetailsAsync(userId);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet("messages")]
        public async Task<IActionResult> GetMessages([FromQuery] bool? isRead)
        {
            var messages = await _adminService.GetAllMessagesAsync(isRead);
            return Ok(messages);
        }

        [HttpPut("messages/{messageId}/read")]
        public async Task<IActionResult> MarkMessageAsRead(int messageId, [FromBody] bool isRead)
        {
            var result = await _adminService.MarkMessageAsReadAsync(messageId, isRead);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}