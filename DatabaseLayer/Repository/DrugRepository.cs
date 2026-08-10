using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class DrugRepository : BaseRepository<Drug> , IDrugRepository  
    {
        public DrugRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Drug> GetByIdasync(Guid id)
        {
            var x = await GetByIdasync(id);
            return x;
        }

        public async Task<List<Drug>> GetbyIdsasync(List<Guid> guids)
        {
            var x = await FindAllAsync(m => guids.Contains(m.Id));
            return x.ToList();
        }
    }
}
