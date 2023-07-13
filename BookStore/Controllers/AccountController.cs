using AutoMapper;
using BookStore.Data;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Identity.Client;

namespace BookStore.Controllers
{
    [ApiController] //proces walidacji modelu automatycznie
    [Route("api/account")]

    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;

        }

        [HttpPost("register")]// oprocz zwyklej sciezki jak kontroler bedzie jeszcze register
        public ActionResult RegisterUser([FromBody] UserDto dto)
        {
            _accountService.RegisterUser(dto);
            //var responseDto = _mapper.Map<UserDto>(dto);
            //responseDto.Role = null;
            return Ok();
            
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto) 
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
