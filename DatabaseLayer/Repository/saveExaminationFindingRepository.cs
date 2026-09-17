using Domain.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<saveExaminationFinding>> GetByAppointmentIdAsync(Guid appointmentId)
        {
            var  x = await _context.saveExaminationFinding.Where(m=> !m.IsDeleted && m.AppointmentId == appointmentId).Include(m => m.ExaminationFinding).ToListAsync();
            return x;
        }

        public async Task<bool> IsCreatBefor(saveExaminationFinding x)
        {
            var M = await _context.saveExaminationFinding.Where(m => m.Value == x.Value && m.AppointmentId == x.AppointmentId && m.ExaminationFindingId == x.ExaminationFindingId && !m.IsDeleted).ToListAsync();
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
