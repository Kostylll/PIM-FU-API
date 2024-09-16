using PIMAPI.Application.Abstraction.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Interfaces
{
    public interface IProductionService
    {
        Task<List<ProductionRequest>> GetProducts();
        
        Task<ProductionRequest> RegisterProducts(ProductionRequest request);
    }
}
