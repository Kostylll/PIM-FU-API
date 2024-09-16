using PIMAPI.Application.Abstraction.Domain.DTO;
using PIMAPI.Application.Abstraction.Domain.Request;
using PIMAPI.Application.Infra.Data.DBContext;
using PIMAPI.Application.Infra.Data.Repository;
using PIMAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Services
{
    public class ProductionService : IProductionService
    {
        private readonly IProductionRepository _productionRepository;

       public ProductionService (IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }

        public async Task<List<ProductionRequest>> GetProducts()
        {
            var products = await _productionRepository.GetAllAsync();

            return products.Select(x => new ProductionRequest
            {
                Id = x.Id,
                Nome_Empresa = x.Nome_Empresa,
                Nome_Produto = x.Nome_Produto,
                Quantidade = x.Quantidade,


            }).ToList();
        }

        public async Task<ProductionRequest> RegisterProducts(ProductionRequest request)
        {
            var newProduct = new Production
            {
                Nome_Empresa = request.Nome_Empresa,
                Nome_Produto = request.Nome_Produto,
                Quantidade = request.Quantidade,
            };

            await _productionRepository.AddAsync(newProduct);
            await _productionRepository.SaveChangesAsync();
            return request;

        }
    }
}
