using Back.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.DTOs
{
    public class AuthDto : User
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
