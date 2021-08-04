using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnaminDemo.Models;
using TechnaminDemo.Services;

namespace TechnaminDemo.Interfaces
{
    public interface IUserService
    {
        AuthenticateUserResponse Authenticate(AuthenticateUserRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
