using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class DiagnosRepository : BaseRepository<Diagnos> , IDiagnosRepository
    {
        public DiagnosRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Diagnos>> GetByAppointmentIdAsync(Guid appointmentId)
        {
           var mm = await FindAllAsync(x => x.AppointmentId == appointmentId && x.IsDeleted == false, new string[] { "DiagnosMaster" });
           mm = mm.OrderByDescending(m=> m.CreatedAt);
           return mm; 
        }
        public async Task<IEnumerable<Diagnos>> GetByDiagnosMasterIdAsync(Guid diagnosMasterId)
        {
            var mm = await FindAllAsync(x => x.DiagnosMasterId == diagnosMasterId && x.IsDeleted == false, new string[] { "DiagnosMaster" });
            mm = mm.OrderByDescending(m => m.CreatedAt);
            return mm;
        }


    }
}
