using Angles.DAL.Models;

namespace Angles.BL.Services
{
    public interface IMessageRepository
    {
        Task<Message> CreateAsync(Message message);
        Task<IEnumerable<Message>> GetAllAsync();
    }
}