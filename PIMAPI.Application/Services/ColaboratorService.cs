using PIMAPI.Application.Abstraction.Domain.DTO;
using PIMAPI.Application.Abstraction.Domain.Request;
using PIMAPI.Application.Infra.Data.DBContext;
using PIMAPI.Application.Infra.Data.Repository;
using PIMAPI.Application.Interfaces;
using PIMAPI.Application.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Services
{
    public class ColaboratorService : IColaboratorService
    {
        
        private readonly IColaboratorRepository _colaboratorRepository;

        public ColaboratorService(IColaboratorRepository colaboratorRepository)
        {
          
            _colaboratorRepository = colaboratorRepository;
        }

        public async Task<int> RegisterColaborator(ColaboratorRequest request)
        {

            var colaborator = new Colaborator()
            {
                Nome = request.Nome,
                Email = request.Email,
                CPF = request.CPF,
                Telefone = request.Telefone,
                Senha = request.CPF,
                Data_Nascimento = FormatDate.FormatDateUtility(request.Data_Nascimento),
                Endereço = request.Endereco

            };

            await _colaboratorRepository.AddAsync(colaborator);
            await _colaboratorRepository.SaveChangesAsync();

            return 1;
        }


        public async Task<List<ColaboratorRequest>> GetColaborator()
        {
            var colaborators = await _colaboratorRepository.GetAllAsync();

            return colaborators.Select(colaborator => new ColaboratorRequest
            {
                Id = colaborator.Id,
                Nome = colaborator.Nome,
                Email = colaborator.Email,
                Telefone = colaborator.Telefone,
                CPF = colaborator.CPF,
                Data_Nascimento = colaborator.Data_Nascimento,
                Endereco = colaborator.Endereço

            }).ToList();
        }

        public async Task<int> DeleteColaborator(string id)
        {
            var colaboratorDeleted = await _colaboratorRepository.GetByIdAsync(id);
            _colaboratorRepository.Delete(colaboratorDeleted);
            await _colaboratorRepository.SaveChangesAsync();
            return 0;
        }

        public async Task<ColaboratorRequest> GetColaboratorById(string id)
        {
            var colaborator = await _colaboratorRepository.GetByIdAsync(id);

            if (colaborator != null)
            {
                var colaboratorViewModel = new ColaboratorRequest()
                {
                   Nome = colaborator.Nome,
                   Email = colaborator.Email,
                   Telefone = colaborator.Telefone,
                   CPF = colaborator.CPF,
                   Data_Nascimento = colaborator.Data_Nascimento,
                   Endereco = colaborator.Endereço,


                };
                return colaboratorViewModel;
            }
            return null;
        }
    }
}
