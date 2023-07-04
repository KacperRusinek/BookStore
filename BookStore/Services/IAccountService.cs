using BookStore.Data;
using BookStore.Models;

namespace BookStore.Services
{
    public interface IAccountService
    {
        void RegisterUser(UserDto dto);
        string GenerateJwt(LoginDto dto);
    }
}
