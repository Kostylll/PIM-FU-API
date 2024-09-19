using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Abstraction.Domain.DTO
{
    public class Vendas : Entity
    {
        public string Nome_Empresa { get; set; }
        public string Produto_Vendido { get; set; }
        public float Quantidade_Vendida {  get; set; }
        public string Local_Vendido { get; set; }
        
    }
}
