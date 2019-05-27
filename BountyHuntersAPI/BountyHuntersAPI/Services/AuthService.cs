using System.Threading.Tasks;
using BountyHuntersAPI.Data.Interfaces;
using BountyHuntersAPI.Dtos.Auth;
using BountyHuntersAPI.Models;
using BountyHuntersAPI.Services.Interfaces;

namespace BountyHuntersAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task Register(UserForRegisterDto userForRegisterDto)
        {
            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            await _repository.Register(userToCreate, userForRegisterDto.Password);
        }

        public async Task<User> Login(string username, string password)
        {
            return await _repository.Login(username, password);
        }
    }
}
