using HRIS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRIS_API.IServices
{
    public interface ILoginService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
