using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRIS_API.IServices;
using HRIS_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Students : ControllerBase
    {
        private IStudentService _oStudentServices;

        public Students(IStudentService oStudentService)
        {
            _oStudentServices = oStudentService;
        }
        // GET: api/<Students>
        [HttpGet]
        //[Authorize]
        public IEnumerable<Student> Get()
        {
            return _oStudentServices.GetAll();
        }

        // GET api/<Students>/5
        [HttpGet("{id}")]
        public Student Get(int studentId)
        {
            return _oStudentServices.Get(studentId);
        }

        // POST api/<Students>
        [HttpPost]
        public Student Post([FromBody] Student oStudent)
        {
            if (ModelState.IsValid)
            {
                return _oStudentServices.Save(oStudent);
            }
            else
            {
                return null;
            }
        }

        // PUT api/<Students>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Students>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _oStudentServices.Delete(id);
        }
    }
}
