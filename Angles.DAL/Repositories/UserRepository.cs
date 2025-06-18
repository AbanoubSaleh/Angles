using Angles.DAL.Data;
using Angles.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Angles.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AnglesDbContext _context;

        public UserRepository(AnglesDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}