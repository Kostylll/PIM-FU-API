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
    public class SupplyService : ISupplyService
    {
        private readonly ISupplyRepository _supplyRepository;

        public SupplyService(ISupplyRepository supplyRepository)
        {
            _supplyRepository = supplyRepository;
        }


        public async Task<List<SupplyRequest>> GetSupply()
        {
            var supplys = await _supplyRepository.GetAllAsync();

            return supplys.Select(supply => new SupplyRequest
            {
                Id = supply.Id,
                CNPJ = supply.CNPJ,
                Endereco = supply.Endereco,
                Nome_Empresa = supply.Nome_Empresa,
                Telefone = supply.Telefone,

            }).ToList();
        }

        public async Task<int> RegisterSupply(SupplyRequest request)
        {
            var supply = new Supply
            {
                CNPJ = request.CNPJ,
                Endereco = request.Endereco,
                Nome_Empresa = request.Nome_Empresa,
                Telefone = request.Telefone,
            };
            await _supplyRepository.AddAsync(supply);
            await _supplyRepository.SaveChangesAsync();
            return 0;
        }
    }
}
