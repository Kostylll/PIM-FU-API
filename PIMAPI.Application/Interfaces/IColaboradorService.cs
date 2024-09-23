using PIMAPI.Application.Abstraction.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Interfaces
{
    public interface IColaboradorService
    {
        Task<int> RegisterColaborator(ColaboradorRequest request);
        Task<List<ColaboradorRequest>> GetColaborator();
        Task<ColaboradorRequest> GetColaboratorById(string id);
        Task<int> DeleteColaborator(string id);
        Task<ColaboradorRequest> UpdateColaborator(string id, ColaboradorRequest request);
    }
}
