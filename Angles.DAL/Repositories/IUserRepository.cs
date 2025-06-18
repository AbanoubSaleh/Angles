using Angles.DAL.Models;
using System.Threading.Tasks;

namespace Angles.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> CreateAsync(User user);
        Task<bool> EmailExistsAsync(string email);
    }
}