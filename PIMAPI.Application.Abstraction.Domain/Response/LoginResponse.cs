using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Abstraction.Domain.Response
{
    public class LoginResponse
    {
        public string token {  get; set; }
        public string Nome { get; set; }

        public string Senha { get; set; }
    }
}
