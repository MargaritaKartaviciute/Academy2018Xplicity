using System.Threading.Tasks;
using BountyHuntersAPI.Models;

namespace BountyHuntersAPI.Data.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
