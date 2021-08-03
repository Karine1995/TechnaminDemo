using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        AuthenticateUser Authenticate(User model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
