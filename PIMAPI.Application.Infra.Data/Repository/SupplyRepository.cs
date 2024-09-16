using Microsoft.EntityFrameworkCore;
using PIMAPI.Application.Abstraction.Domain;
using PIMAPI.Application.Abstraction.Domain.DTO;
using PIMAPI.Application.Infra.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Infra.Data.Repository
{
    public class SupplyRepository : Repository<Supply> , ISupplyRepository
    {
        public SupplyRepository(PIMAPIdb context) : base(context)
        {
        }
    }
}
