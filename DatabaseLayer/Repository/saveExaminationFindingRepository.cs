using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class saveExaminationFindingRepository : BaseRepository<saveExaminationFinding>, IsaveExaminationFindingRepository
    {
        public saveExaminationFindingRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
