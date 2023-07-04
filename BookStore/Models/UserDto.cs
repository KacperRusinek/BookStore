using BookStore.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class UserDto
    {
        //primary key
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; } //nie jest data urodzenia wymagana
        public string Nationality { get; set; }
        public string? PasswordHash { get; set; }
        public int RoleId { get; set; } //klucz obcy do połączenia dwóch tabel
        public virtual Role Role { get; set; } //reprezentuje daną rolę użytkownika 


    }
}
