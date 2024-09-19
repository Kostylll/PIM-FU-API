using PIMAPI.Application.Abstraction.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Interfaces
{
    public interface IFornecedoresService
    {
        Task<List<FornecedoresRequest>> GetSupply();

        Task<int> RegisterSupply(FornecedoresRequest request);
    }
}
