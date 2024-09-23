using PIMAPI.Application.Abstraction.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Interfaces
{
    public interface IVendasService
    {
        Task<List<VendasRequest>> GetSales();
        Task<VendasRequest> UpdateSales(string id,  VendasRequest request);
        Task<int> RegisterSale(VendasRequest request);
    }
}
