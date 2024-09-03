using PIMAPI.Application.Abstraction.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Interfaces
{
    public interface ILoginService
    {
        Task<string> GetLogin(LoginResponse loginResponse);
    }
}
