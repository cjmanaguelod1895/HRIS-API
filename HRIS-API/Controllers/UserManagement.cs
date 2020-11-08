﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRIS_API.IServices;
using HRIS_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagement : ControllerBase
    {
        private IUsersService _oUsersService;
        public UserManagement(IUsersService oUsersService)
        {
            _oUsersService = oUsersService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _oUsersService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        // GET: api/<UserManagement>
        [HttpGet]
        [Authorize]
        public IEnumerable<Users> Get()
        {
            return _oUsersService.GetAllUsers();
        }

        // GET api/<UserManagement>/5
        [HttpGet("{id}")]
        public Users Get(int id)
        {
            return _oUsersService.GetUser(id);
        }

        // POST api/<UserManagement>
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

        // PUT api/<UserManagement>/5
        [HttpPut("{id}")]
        public Users Put(int id, [FromBody] Users oUsers)
        {
            if (ModelState.IsValid)
            {
                return _oUsersService.UpdateUser(id, oUsers);
            }
            else
            {
                return null;
            }
        }

        // DELETE api/<UserManagement>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _oUsersService.Delete(id);
        }
    }
}
