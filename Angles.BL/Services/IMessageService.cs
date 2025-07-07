using Angles.BL.DTOs;
using Angles.BL.DTOs.Admin;

namespace Angles.BL.Services
{
    public interface IMessageService
    {
        Task<bool> CreateMessageAsync(MessageDto messageDto);
        Task<IEnumerable<ReadMessageDto>> GetAllMessagesAsync();
    }
}