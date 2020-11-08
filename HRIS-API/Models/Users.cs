using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRIS_API.Models
{
    public class Users
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Age { get; set; }

        public string Address { get; set; }

        public string EmailAddress { get; set; }


        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }


        public string Message { get; set; }


        public DynamicParameters SetParameters(Users oUser, int operationType)
        {


            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", oUser.UserId);
            parameters.Add("@Name", oUser.Name);
            parameters.Add("@Age", oUser.Age);
            parameters.Add("@Address", oUser.Address);
            parameters.Add("@EmailAddress", oUser.EmailAddress);
            parameters.Add("@Username", oUser.Username);
            parameters.Add("@Password", oUser.Password);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }

    }
}
