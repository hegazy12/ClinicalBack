using Domain.IRepository;
using Domain.Models;



namespace DatabaseLayer.Repository
{
    public class saveExaminationsRepository : BaseRepository<saveExamination> , IsaveExaminationsRepository
    {
        public saveExaminationsRepository(AppDbContext context) : base(context){ 

        }

        public async Task<saveExamination> Save(saveExamination x)
        {
            var m  = await AddAsync(x);
            return m;
        }

        public async Task<IEnumerable<saveExamination>> GetbyAppoitmentIDAsync(Guid id)
        {
            var m = await FindAllAsync(m => m.AppointmentId == id , new string[] { "medicalExamination" , "Appointment" , "Created" });
            
            return m;
        }

        public async Task<IEnumerable<saveExamination>> GetbyIdes(List<Guid> ids)
        {
            var m = await FindAllAsync(m => ids.Contains(m.Id));
            return m;
        }

        public Task<IEnumerable<saveExamination>> GetbyAppoitmentID(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
