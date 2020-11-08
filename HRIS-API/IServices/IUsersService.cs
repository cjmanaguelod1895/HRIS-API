using HRIS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRIS_API.IServices
{
    public interface IUsersService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        List<Users> GetAllUsers();

        Users GetUser(int userId);

        Users AddUser(Users users);

        Users UpdateUser(int userId, Users user);


        string Delete(int userId);
    }
}
