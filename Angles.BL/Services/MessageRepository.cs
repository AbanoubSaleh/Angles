using Angles.DAL.Data;
using Angles.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Angles.BL.Services
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AnglesDbContext _context;

        public MessageRepository(AnglesDbContext context)
        {
            _context = context;
        }

        public async Task<Message> CreateAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<IEnumerable<Message>> GetAllAsync()
        {
            return await _context.Messages
                .Include(m => m.User)
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();
        }
    }
}