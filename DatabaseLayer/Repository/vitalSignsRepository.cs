using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class vitalSignsRepository : BaseRepository<VitalSign>, IvitalSignsRepository
    {

        public vitalSignsRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<VitalSign>> GetSearchTearmAsync(string SearchTearm)
        {
            return await FindAllAsync(m => m.name.Contains(SearchTearm), new string[] { "VitalSignMaster" });
        }
    }
}
