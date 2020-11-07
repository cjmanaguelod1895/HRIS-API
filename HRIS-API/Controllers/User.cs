using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRIS_API.IServices;
using HRIS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        private IUsersService _oUsersService;
        public User(IUsersService oUsersService)
        {
            _oUsersService = oUsersService;
        }

        // GET: api/<User>
        [HttpGet]
        //[Authorize]
        public IEnumerable<Users> Get()
        {
            return _oUsersService.GetAllUsers();
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public Users Get(int userId)
        {
            return _oUsersService.GetUser(userId);
        }

        // POST api/<User>
        [HttpPost]
        public Users Post([FromBody] Users oUsers)
        {
            if (ModelState.IsValid)
            {
                return _oUsersService.AddUser(oUsers);
            }
            else
            {
                return null;
            }
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}")]
        public string Delete(int userId)
        {
            return _oUsersService.Delete(userId);
        }


    }
}
