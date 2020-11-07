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
    public class UsersService: IUsersService
    {
        Users _oUser = new Users();
        List<Users> _oUsers = new List<Users>();

        public List<Users> GetAllUsers()
        {
            _oUser = new Users();
            _oUsers = new List<Users>();

            try
            {
                int operationType = Convert.ToInt32(OperationType.SelectAll);

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oUsers = con.Query<Users>("SP_Users",
                       this.SetParameters(_oUser, operationType),
                       commandType: CommandType.StoredProcedure);


                    if (oUsers != null && oUsers.Count() > 0)
                    {
                        _oUsers = oUsers.ToList();
                    }
                }
            }
            catch (Exception ex)
            {

                _oUser.Message = ex.Message;
            }

            return _oUsers;
        }

        public Users GetUser(int userID)
        {


            _oUser = new Users()
            {
                UserId = userID
            };

            try
            {
                int operationType = Convert.ToInt32(OperationType.SelectSpecific);

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oUsers = con.Query<Users>("SP_Users",
                       this.SetParameters(_oUser, operationType),
                       commandType: CommandType.StoredProcedure).ToList();

                    if (oUsers != null && oUsers.Count() > 0)
                    {
                        _oUser = oUsers.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _oUser.Message = ex.Message;
            }

            return _oUser;
        }


        public Users AddUser(Users users)
        {
            _oUser = new Users();

            try
            {
                int operationType = Convert.ToInt32(users.UserId == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oUsers = con.Query<Users>("SP_Users",
                        this.SetParameters(users, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oUsers != null && oUsers.Count() > 0)
                    {
                        _oUser = oUsers.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _oUser.Message = ex.Message;
            }

            return _oUser;


        }

        public Users UpdateUser(int userId, Users user)
        {
            _oUser = new Users();

            try
            {
                int operationType = Convert.ToInt32(OperationType.Update);

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oUsers = con.Query<Users>("SP_Users",
                        this.SetParameters(user, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oUsers != null && oUsers.Count() > 0)
                    {
                        _oUser = oUsers.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _oUser.Message = ex.Message;
            }

            return _oUser;
        }

        public string Delete(int userId)
        {
            string message = "";

            try
            {
                _oUser = new Users()
                {
                    UserId = userId
                };

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    var oUsers = con.Query<Users>("SP_Users",
                        this.SetParameters(_oUser, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oUsers != null && oUsers.Count() > 0)
                    {
                        _oUser = oUsers.FirstOrDefault();

                        message = "Data Deleted!";
                    }
                }
            }
            catch (Exception ex)
            {

                message = ex.Message;
            }

            return message;
        }


        private DynamicParameters SetParameters(Users oUser, int operationType)
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
