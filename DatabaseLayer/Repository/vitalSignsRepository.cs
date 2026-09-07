using DatabaseLayer.Migrations;
using Domain.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace DatabaseLayer.Repository
{
    public class vitalSignsRepository : BaseRepository<VitalSign>, IvitalSignsRepository
    {

        public vitalSignsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<VitalSign>> GetSearchTearmAsync(string SearchTearm)
        {
            return await FindAllAsync(m => m.name.Contains(SearchTearm) && !m.IsDeleted, new string[] { "VitalSignMaster" });
        }

        public async Task<saveVitalSign> save(saveVitalSign saveVitalSign)
        {
            var result = await _context.saveVitalSigns.AddAsync(saveVitalSign);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IList<saveVitalSign>> GetByAppointmentIdAsync(Guid id)
        {
            return await _context.saveVitalSigns
                .Where(m => m.AppointmentId == id && !m.IsDeleted)
                .Include(m => m.Appointment)
                .Include(m => m.VitalSign).
                ThenInclude(m=> m.VitalSignMaster)
                .ToListAsync();
        }

        
    }
}
