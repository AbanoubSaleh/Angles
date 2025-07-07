
using Angles.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Angles.DAL.Data
{
    public class AnglesDbContext : IdentityDbContext<User>
    {
        public AnglesDbContext(DbContextOptions<AnglesDbContext> options)
            : base(options)
        {
        }

        // Remove the DbSet<User> if it's already included in IdentityDbContext
        public DbSet<User> Users { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}