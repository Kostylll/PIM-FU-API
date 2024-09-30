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
    public class ProdutoService : IProdutoService
    {
        private readonly IProductionRepository _productionRepository;

       public ProdutoService (IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }

        public async Task<int> DeleteProduct(string id)
        {
            var productDelete = await _productionRepository.GetByIdAsync(id);
            _productionRepository.Delete(productDelete);
            await _productionRepository.SaveChangesAsync();
            return 0;
        }

        public async Task<List<ProdutoRequest>> GetProducts()
        {
            var products = await _productionRepository.GetAllAsync();

            return products.Select(x => new ProdutoRequest
            {
                Id = x.Id,
                Nome_Empresa = x.Nome_Empresa,
                Nome_Produto = x.Nome_Produto,
                Quantidade = x.Quantidade,


            }).ToList();
        }

        public async Task<ProdutoRequest> RegisterProducts(ProdutoRequest request)
        {
            var newProduct = new Produtos
            {
                Nome_Empresa = request.Nome_Empresa,
                Nome_Produto = request.Nome_Produto,
                Quantidade = request.Quantidade,
            };

            await _productionRepository.AddAsync(newProduct);
            await _productionRepository.SaveChangesAsync();
            return request;

        }

        public async Task<ProdutoRequest> UpdateProducts(string id, ProdutoRequest request)
        {
           var product = await _productionRepository.GetByIdAsync(id);

            if(product != null)
            {
                product.Nome_Empresa = request.Nome_Empresa;
                product.Nome_Produto = request.Nome_Produto;
                product.Quantidade = request.Quantidade;

                _productionRepository.Update(product);
                await _productionRepository.SaveChangesAsync();
            }
            else
            {
                return null;
            }
            return request;
        }
    }
}
