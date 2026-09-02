using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IDiagnosMasterRepository : IBaseRepository<DiagnosMaster>
    {
        public Task<IEnumerable<DiagnosMaster>> GetSearchTearmAsync(string SearchTearm);
    }
}
