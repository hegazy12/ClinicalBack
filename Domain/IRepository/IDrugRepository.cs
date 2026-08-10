using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IDrugRepository : IBaseRepository<Drug>
    {
        public Task<Drug> GetByIdasync(Guid id);
        public Task<List<Drug>> GetbyIdsasync(List<Guid> guids);
        
    }
}
