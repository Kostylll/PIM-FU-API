using PIMAPI.Application.Abstraction.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Interfaces
{
    public interface IColaboratorService
    {
        Task<int> RegisterColaborator(ColaboratorRequest request);

        Task<List<ColaboratorRequest>> GetColaborator();

        Task<ColaboratorRequest> GetColaboratorById(string id);

        Task<int> DeleteColaborator(string id);
    }
}
