using System;
using Microsoft.AspNetCore.Identity;

namespace Back.Data.Models.Entities
{
    public class User : IdentityUser
    {
        protected internal User() => RegisteredDate = DateTime.UtcNow;
  
        public string Name { get; set; }

        public string LastName { get; set; }

        public override string UserName => Email;

        public int Age { get; set; }

        public DateTime RegisteredDate { get; set; }

        public byte[] Timestamp { get; set; }
    }
}