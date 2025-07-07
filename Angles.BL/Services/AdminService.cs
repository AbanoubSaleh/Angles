using Angles.BL.DTOs;
using Angles.BL.DTOs.Admin;
using Angles.DAL.Data;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace Angles.BL.Services
{
    public class AdminService : IAdminService
    {
        private readonly AnglesDbContext _context;

        public AdminService(AnglesDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardStatsDto> GetDashboardStatsAsync()
        {
            var stats = new DashboardStatsDto
            {
                TotalUsers = await _context.Users.CountAsync(),
                TotalDonations = await _context.Donations.CountAsync(),
                TotalMessages = await _context.Messages.CountAsync(),
                TotalDonationsAmount = await _context.Donations.SumAsync(d => d.Amount),
                RecentMessages = await _context.Messages
                    .OrderByDescending(m => m.CreatedAt)
                    .Take(5)
                    .Select(m => new MessageDto
                    {
                        FirstName = m.FirstName,
                        LastName = m.LastName,
                        Email = m.Email,
                        Content = m.Content,
                        UserId = m.UserId,
                        Phone = m.Phone
                    })
                    .ToListAsync()
            };

            return stats;
        }

        public async Task<IEnumerable<DonationResultDto>> GetAllDonationsAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.Donations.AsQueryable();

            if (startDate.HasValue)
                query = query.Where(d => d.CreatedAt >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(d => d.CreatedAt <= endDate.Value);

            var donations = await query
                .OrderByDescending(d => d.CreatedAt)
                .Select(d => DonationResultDto.MapfromEntity(d))
                .ToListAsync();

            return donations;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync(string? searchTerm = null)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(u => 
                    u.Email.Contains(searchTerm) || 
                    u.FirstName.Contains(searchTerm) || 
                    u.LastName.Contains(searchTerm));
            }

            return await query
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Phone = u.PhoneNumber
                })
                .ToListAsync();
        }

        public async Task<UserDto> GetUserDetailsAsync(string userId)
        {
            var user = await _context.Users
                .Include(u => u.Donations)
                .Include(u => u.Messages)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.PhoneNumber
            };
        }

        public async Task<IEnumerable<ReadMessageDto>> GetAllMessagesAsync(bool? isRead = null)
        {
            var query = _context.Messages.AsQueryable();

            if (isRead.HasValue)
                query = query.Where(m => m.IsRead == isRead.Value);

            return await query
                .OrderByDescending(m => m.CreatedAt)
                .Select(m => new ReadMessageDto
                {
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Email = m.Email,
                    Phone = m.Phone,
                    Content = m.Content,
                    UserId = m.UserId,
                    Id = m.Id
                })
                .ToListAsync();
        }

        public async Task<bool> MarkMessageAsReadAsync(int messageId, bool isRead)
        {
            var message = await _context.Messages.FindAsync(messageId);
            if (message == null) return false;

            message.IsRead = isRead;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<byte[]> ExportDonationsToExcelAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var donations = await GetAllDonationsAsync(startDate, endDate);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Donations");

                // Add headers
                worksheet.Cells[1, 1].Value = "Full Name";
                worksheet.Cells[1, 2].Value = "Email";
                worksheet.Cells[1, 3].Value = "Phone";
                worksheet.Cells[1, 4].Value = "Amount";
                worksheet.Cells[1, 5].Value = "Provider";
                worksheet.Cells[1, 6].Value = "Country";

                int row = 2;
                foreach (var donation in donations)
                {
                    worksheet.Cells[row, 1].Value = donation.FullName;
                    worksheet.Cells[row, 2].Value = donation.Email;
                    worksheet.Cells[row, 3].Value = donation.Phone;
                    worksheet.Cells[row, 4].Value = donation.Amount;
                    worksheet.Cells[row, 5].Value = donation.ProviderName;
                    worksheet.Cells[row, 6].Value = donation.Country;
                    row++;
                }

                return package.GetAsByteArray(); // Changed from GetAsByteArrayAsync to GetAsByteArray
            }
        }
    }
}