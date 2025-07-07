namespace Angles.BL.DTOs.Admin
{
    public class DashboardStatsDto
    {
        public int TotalUsers { get; set; }
        public int TotalDonations { get; set; }
        public int TotalMessages { get; set; }
        public double TotalDonationsAmount { get; set; }
        public List<MessageDto> RecentMessages { get; set; } = new();
        public List<RecentActivityDto> RecentActivities { get; set; } = new();
    }

    public class RecentActivityDto
    {
        public string Type { get; set; } // "Donation" or "Message"
        public string UserName { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
    }
}