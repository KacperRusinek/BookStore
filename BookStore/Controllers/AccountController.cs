using BookStore.Data;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BookStore.Controllers
{
    [ApiController] //proces walidacji modelu automatycznie
    [Route("api/account")]

    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]// oprocz zwyklej sciezki jak kkontroler bedzie jeszcze register
        public ActionResult RegisterUser([FromBody] UserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok(dto);
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto) 
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
