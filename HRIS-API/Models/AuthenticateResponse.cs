using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRIS_API.Models
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }

        public string Token { get; set; }

        public AuthenticateResponse(Users user, string token)
        {
            UserId = user.UserId;
            Name = user.Name;
            Username = user.Username;
            Role = user.Role;
            Token = token;
        }

    }
}
