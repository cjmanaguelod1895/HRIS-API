using HRIS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRIS_API.IServices
{
    public interface IUsersService
    {
        List<Users> GetAllUsers();

        Users GetUser(int userID);

        Users AddUser(Users users);

        string Delete(int userId);
    }
}
