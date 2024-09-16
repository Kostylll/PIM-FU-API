using PIMAPI.Application.Abstraction.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Interfaces
{
    public interface ISupplyService
    {
        Task<List<SupplyRequest>> GetSupply();

        Task<int> RegisterSupply(SupplyRequest request);
    }
}
