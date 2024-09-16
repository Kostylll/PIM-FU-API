using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Abstraction.Domain.Request
{
    public class SupplyRequest
    {
        public string Id { get; set; }
        public string Nome_Empresa { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
