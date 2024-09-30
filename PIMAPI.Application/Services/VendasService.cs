using PIMAPI.Application.Abstraction.Domain.DTO;
using PIMAPI.Application.Abstraction.Domain.Request;
using PIMAPI.Application.Infra.Data.Repository;
using PIMAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Services
{
    public class VendasService : IVendasService
    {
        private readonly IVendasRepository _saleRepository;

        public VendasService(IVendasRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<int> DeleteSale(string id)
        {
            var saleDelete = await _saleRepository.GetByIdAsync(id);
            _saleRepository.Delete(saleDelete);
            await _saleRepository.SaveChangesAsync();
            return 0;
        }

        public async Task<List<VendasRequest>> GetSales()
        {
            var sales = await _saleRepository.GetAllAsync();

            return sales.Select(sale => new VendasRequest
            {
                Id = sale.Id,
                Nome_Empresa = sale.Nome_Empresa,
                Local_Vendido = sale.Local_Vendido,
                Produto_Vendido = sale.Produto_Vendido,
                Quantidade_Vendida = sale.Quantidade_Vendida 

            }).ToList();
        }

        public async Task<int> RegisterSale(VendasRequest request)
        {
            var sale = new Vendas
            {
                Nome_Empresa = request.Nome_Empresa,
                Local_Vendido = request.Local_Vendido,
                Produto_Vendido = request.Produto_Vendido,
                Quantidade_Vendida = request.Quantidade_Vendida,
            };
            await _saleRepository.AddAsync(sale);
            await _saleRepository.SaveChangesAsync();
            return 0;
        }

        public async Task<VendasRequest> UpdateSales(string id, VendasRequest request)
        {
            var sale = await _saleRepository.GetByIdAsync(id);

            if(sale != null)
            {
                sale.Nome_Empresa = request.Nome_Empresa;
                sale.Local_Vendido = request.Local_Vendido; 
                sale.Produto_Vendido= request.Produto_Vendido;
                sale.Quantidade_Vendida = request.Quantidade_Vendida;

                _saleRepository.Update(sale);
                await _saleRepository.SaveChangesAsync();
            }
            else
            {
                return null;
            }
            return request;
        }
    }
}
