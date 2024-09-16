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
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(PIMAPIdb context) : base(context)
        {
        }
    }
}
