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
    public class FornecedoresService : IFornecedoresService
    {
        private readonly IFornecedoresRepository _supplyRepository;

        public FornecedoresService(IFornecedoresRepository supplyRepository)
        {
            _supplyRepository = supplyRepository;
        }


        public async Task<List<FornecedoresRequest>> GetSupply()
        {
            var supplys = await _supplyRepository.GetAllAsync();

            return supplys.Select(supply => new FornecedoresRequest
            {
                Id = supply.Id,
                CNPJ = supply.CNPJ,
                Endereco = supply.Endereco,
                Nome_Empresa = supply.Nome_Empresa,
                Telefone = supply.Telefone,

            }).ToList();
        }

        public async Task<int> RegisterSupply(FornecedoresRequest request)
        {
            var supply = new Fornecedores
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

        public async Task<FornecedoresRequest> UpdateSupply(string id, FornecedoresRequest request)
        {
            var supply = await _supplyRepository.GetByIdAsync(id);

            if(supply != null)
            {
                supply.CNPJ = request.CNPJ;
                supply.Endereco = request.Endereco;
                supply.Nome_Empresa = request.Nome_Empresa;
                supply.Telefone = request.Telefone;

                _supplyRepository.Update(supply);
                await _supplyRepository.SaveChangesAsync();
            }
            else
            {
                return null;
            }
            return request;
        }
    }
}
