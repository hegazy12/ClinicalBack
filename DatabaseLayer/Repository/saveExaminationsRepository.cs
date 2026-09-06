using Domain.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;



namespace DatabaseLayer.Repository
{
    public class saveExaminationsRepository : BaseRepository<saveExamination> , IsaveExaminationsRepository
    {
        public saveExaminationsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<saveExamination> Save(saveExamination x)
        {
            var m  = await AddAsync(x);
            return m;
        }

        public async Task<IEnumerable<saveExamination>> GetbyAppoitmentIDAsync(Guid id)
        {
            var m = await FindAllAsync(m => m.AppointmentId == id && !m.IsDeleted  , new string[] { "medicalExamination" , "Appointment" , "Created" });
            
            return m;
        }

        public async Task<IEnumerable<saveExamination>> GetbyIdes(List<Guid> ids)
        {
            var m = await FindAllAsync(m => ids.Contains(m.Id) && !m.IsDeleted);
            return m;
        }

        public Task<IEnumerable<saveExamination>> GetbyAppoitmentID(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<saveExamination?> GetByIdFull(Guid id)
        {
            var examination = await _context.saveExamination
                .Include(e => e.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(e => e.medicalExamination)
                .Include(e => e.ExaminationPhotos)
                .FirstOrDefaultAsync(e => e.Id == id);

            return examination;
        }

        public async Task<IEnumerable<saveExaminationPhotos>> GetExaminationsByIdPhotos(Guid id)
        {
            var x = await _context.saveExaminationPhotos.Where(m => m.examinationId == id && !m.IsDeleted).ToListAsync();
            return x; 
        }
    }
}
