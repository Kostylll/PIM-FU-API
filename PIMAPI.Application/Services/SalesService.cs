﻿using PIMAPI.Application.Abstraction.Domain.DTO;
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
    public class SalesService : ISalesService
    {
        private readonly ISaleRepository _saleRepository;

        public SalesService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public async Task<List<SaleRequest>> GetSales()
        {
            var sales = await _saleRepository.GetAllAsync();

            return sales.Select(sale => new SaleRequest
            {
                Id = sale.Id,
                Nome_Empresa = sale.Nome_Empresa,
                Local_Vendido = sale.Local_Vendido,
                Produto_Vendido = sale.Produto_Vendido,
                Quantidade_Vendida = sale.Quantidade_Vendida 

            }).ToList();
        }

        public async Task<int> RegisterSale(SaleRequest request)
        {
            var sale = new Sale
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
    }
}
