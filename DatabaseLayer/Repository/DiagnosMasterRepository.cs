using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class DiagnosMasterRepository : BaseRepository<DiagnosMaster>, IDiagnosMasterRepository
    {
        public DiagnosMasterRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiagnosMaster>> GetSearchTearmAsync(string SearchTearm)
        {
            return await FindAllAsync(m => m.Name.Contains(SearchTearm) && !m.IsDeleted);
        }
    }
}
