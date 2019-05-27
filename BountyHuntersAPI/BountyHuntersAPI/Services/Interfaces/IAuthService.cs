using System.Threading.Tasks;
using BountyHuntersAPI.Dtos.Auth;
using BountyHuntersAPI.Models;

namespace BountyHuntersAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task Register(UserForRegisterDto userForRegisterDto);
        Task<User> Login(string username, string password);
    }
}
