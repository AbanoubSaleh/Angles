using Angles.BL.DTOs;
using Angles.BL.DTOs.Admin;

namespace Angles.BL.Services
{
    public interface IAdminService
    {
        Task<DashboardStatsDto> GetDashboardStatsAsync();
        Task<IEnumerable<DonationResultDto>> GetAllDonationsAsync(DateTime? startDate = null, DateTime? endDate = null);
        Task<IEnumerable<UserDto>> GetAllUsersAsync(string? searchTerm = null);
        Task<UserDto> GetUserDetailsAsync(string userId);
        Task<IEnumerable<ReadMessageDto>> GetAllMessagesAsync(bool? isRead = null);
        Task<bool> MarkMessageAsReadAsync(int messageId, bool isRead);
        Task<byte[]> ExportDonationsToExcelAsync(DateTime? startDate = null, DateTime? endDate = null);
    }
}