using Dapper;
using HRIS_API.Common;
using HRIS_API.IServices;
using HRIS_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HRIS_API.Services
{
    public class StudentService : IStudentService
    {
        Student _oStudent = new Student();
        List<Student> _oStudents = new List<Student>();

        public string Delete(int studentId)
        {
            string message = "";

            try
            {
                _oStudent = new Student()
                {
                    StudentId = studentId
                };

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oStudents = con.Query<Student>("SP_Student",
                        this.SetParameters(_oStudent, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oStudents != null && oStudents.Count() > 0)
                    {
                        _oStudent = oStudents.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                message = ex.Message;
            }

            return message;
        }

        public Student Get(int studentId)
        {
            _oStudent = new Student();

            try
            {
                //int operationType = Convert.ToInt32(oStudent.StudentId == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oStudents = con.Query<Student>("SELECT * FROM Student WHERE studentId = " + studentId).ToList();

                    if (oStudents != null && oStudents.Count() > 0)
                    {
                        _oStudent = oStudents.SingleOrDefault();
                    }
                }

            }
            catch (Exception ex)
            {

                _oStudent.Message = ex.Message;
            }

            return _oStudent;
        }

        public List<Student> GetAll()
        {
            _oStudents = new List<Student>();

            try
            {
                //int operationType = Convert.ToInt32(oStudent.StudentId == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oStudents = con.Query<Student>("SELECT * FROM Student").ToList();

                    if (oStudents != null && oStudents.Count() > 0)
                    {
                        _oStudents = oStudents;
                    }
                }

            }
            catch (Exception ex)
            {

                _oStudent.Message = ex.Message;
            }

            return _oStudents;
        }

        public Student Save(Student oStudent)
        {
            _oStudent = new Student();
            try
            {
                int operationType = Convert.ToInt32(oStudent.StudentId == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oStudents = con.Query<Student>("SP_Student",
                        this.SetParameters(oStudent, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oStudents != null && oStudents.Count() > 0)
                    {
                        _oStudent = oStudents.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _oStudent.Message = ex.Message;
            }

            return _oStudent;
        }

        private DynamicParameters SetParameters(Student oStudent, int operationType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@StudentId", oStudent.StudentId);
            parameters.Add("@Name", oStudent.Name);
            parameters.Add("@Roll", oStudent.Roll);
            parameters.Add("@OperationType", operationType);

            return parameters;
        }
    }
}
