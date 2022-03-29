using Back.Data.Models.Entities;

namespace Back.DTOs
{
    public class AuthDto : User
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}