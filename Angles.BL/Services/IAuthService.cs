using Angles.BL.DTOs;
using System.Threading.Tasks;

namespace Angles.BL.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> SignUpAsync(SignUpDto signUpDto);
        Task<AuthResponseDto> SignInAsync(SignInDto signInDto);
    }
}