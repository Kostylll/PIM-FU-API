using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Abstraction.Domain.Request
{
    public class SaleRequest
    {
        public string Id { get; set; }
        public string Nome_Empresa { get; set; }
        public string Produto_Vendido { get; set; }
        public float Quantidade_Vendida { get; set; }
        public string Local_Vendido { get; set; }
    }
}
