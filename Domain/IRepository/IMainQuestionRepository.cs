using Domain.Models;

namespace Domain.IRepository
{
    public interface IMainQuestionRepository : IBaseRepository<MainQuestion>
    {
        public Task<bool> IsCreatBefor(MainQuestion x);
        public Task<IEnumerable<MainQuestion>> GetbyPatientId(Guid PatientId);
    }
}
