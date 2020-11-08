using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using HRIS_API.Common;
using HRIS_API.Helpers;
using HRIS_API.IServices;
using HRIS_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRIS_API.Controllers
{
    [Route("HRIS-API/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        private ILoginService _oLoginService;
        public Login(ILoginService oLoginService)
        {
            _oLoginService = oLoginService;
        }

        [HttpPost]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _oLoginService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
