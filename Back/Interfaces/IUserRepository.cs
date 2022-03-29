using Back.Data.Models.Entities;
using Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers(PaginationParameters userParameters);
        User GetUserById(string id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
