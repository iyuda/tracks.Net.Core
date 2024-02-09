using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRACSPortal.Models
{
    public class User
    {
        public User(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public string Username { get; }
        public string Email { get; }
    }
}
