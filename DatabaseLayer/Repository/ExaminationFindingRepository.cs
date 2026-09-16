using Domain.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class ExaminationFindingRepository : BaseRepository<ExaminationFinding>, IExaminationFindingRepository
    {
        public ExaminationFindingRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsCreatBefor(ExaminationFinding x)
        {
            var M = await  _context.ExaminationFindings.Where(m=> m.Name == x.Name && !m.IsDeleted ).ToListAsync();
            if (M.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
