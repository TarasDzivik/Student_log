using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.DTOs
{
    public class RegistrationDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string Email { get; set; }
        //public string Password { get; set; }

        public DateTime RegisteredDate { get; set; }
    }
}
