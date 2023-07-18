using BookStore.Data;
using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IAccountService
    {
        public void RegisterUser(UserDto dto);
        public string GenerateJwt(LoginDto dto);
    }
}
