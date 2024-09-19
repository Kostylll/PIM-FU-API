using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Abstraction.Domain.DTO
{
    public class Produtos : Entity
    {
        public string Nome_Produto { get; set; }
        public float Quantidade { get; set; }
        public string Nome_Empresa { get; set; }
       
    }
}
