using AutoMapper;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.Services
{
    public class AccountService : IAccountService
    {
        private readonly AuthenticationSettings _settings;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _dbContext;
        public AccountService(BookStoreDbContext bookStoreDb,IMapper mapper, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _dbContext = bookStoreDb;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _settings = authenticationSettings;
        }
        public void RegisterUser(UserDto user)
        {
            var usere = _mapper.Map<User>(user);
            var UsereHash = _passwordHasher.HashPassword(usere, user.PasswordHash);
            usere.PasswordHash = UsereHash; 
            _dbContext.Users.Add(usere);
            _dbContext.SaveChanges();              
        }
        public string GenerateJwt(LoginDto dto)
        {
            var user = _dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == dto.Email);
                
            
            if(user is null) 
            {
                throw new BadHttpRequestException("Invalid username or password"); //wyjątek do obsłużenia w middleware
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadHttpRequestException("Invalid username or password"); 
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd")),
                new Claim("Nationality", user.Nationality)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_settings.JwtExpireDays);

            var token = new JwtSecurityToken(_settings.JwtIssuer,
                _settings.JwtIssuer,
                claims,
                expires,
                signingCredentials: cred);
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

        }

    }
}
