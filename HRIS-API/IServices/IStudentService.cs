using HRIS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRIS_API.IServices
{
    public interface IStudentService
    {
        Student Save(Student oStudent);

        List<Student> GetAll();

        Student Get(int studentId);

        string Delete(int studentId);
    }
}
