using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using en = DAL.Entities;

namespace TechnaminDemo.Models
{
    public class AuthenticateUserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateUserResponse(en.User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Token = token;
        }
    }
}
