using PIMAPI.Application.Abstraction.Domain.Response;
using PIMAPI.Application.Infra.Data.DBContext;
using PIMAPI.Application.Infra.Data.Repository;
using PIMAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly PIMAPIdb _context;

        public LoginService(ILoginRepository loginRepository, PIMAPIdb context)
        {
            _loginRepository = loginRepository;
            _context = context;
        }

        public async Task<string> GetLogin(LoginResponse loginResponse)
        {
            var colaborator = _context.Colaborator
                .FirstOrDefault(x => x.Nome == loginResponse.Nome && x.Senha == loginResponse.Senha);

            if (colaborator != null)
            {
                var userId = colaborator.Id.ToString();
                return await Task.FromResult(userId);
            }
            else
            {
                return await Task.FromResult<string>(null);
            }
        }
    }
}
    
