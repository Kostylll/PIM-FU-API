using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Abstraction.Domain.DTO
{
    public class Colaboradores : Entity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public string Endereço { get; set; }
        public string Data_Nascimento { get; set; }


    }
}
