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
    public class ColaboradorService : IColaboradorService
    {
        
        private readonly IColaboradorRepository _colaboratorRepository;

        public ColaboradorService(IColaboradorRepository colaboratorRepository)
        {
          
            _colaboratorRepository = colaboratorRepository;
        }

        public async Task<int> RegisterColaborator(ColaboradorRequest request)
        {

            var colaborator = new Colaboradores()
            {
                Nome = request.Nome,
                Email = request.Email,
                CPF = request.CPF,
                Telefone = request.Telefone,
                Senha = request.CPF,
                Data_Nascimento = request.Data_Nascimento,
                Endereço = request.Endereco

            };

            await _colaboratorRepository.AddAsync(colaborator);
            await _colaboratorRepository.SaveChangesAsync();

            return 1;
        }


        public async Task<List<ColaboradorRequest>> GetColaborator()
        {
            var colaborators = await _colaboratorRepository.GetAllAsync();

            return colaborators.Select(colaborator => new ColaboradorRequest
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

        public async Task<ColaboradorRequest> GetColaboratorById(string id)
        {
            var colaborator = await _colaboratorRepository.GetByIdAsync(id);

            if (colaborator != null)
            {
                var colaboratorViewModel = new ColaboradorRequest()
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

        public async Task<ColaboradorRequest> UpdateColaborator(string id, ColaboradorRequest request)
        {
            var colaborator = await _colaboratorRepository.GetByIdAsync(id);

            if (colaborator != null)
            {
                colaborator.Nome = request.Nome;
                colaborator.Email = request.Email;
                colaborator.Endereço = request.Endereco;
                colaborator.Email = request.Email;
                colaborator.Data_Nascimento = request.Data_Nascimento;
                colaborator.CPF = request.CPF;

                 _colaboratorRepository.Update(colaborator);
                await _colaboratorRepository.SaveChangesAsync();


            }
            else
            {
                return null;
            }
            return request;
        }
    }
}
