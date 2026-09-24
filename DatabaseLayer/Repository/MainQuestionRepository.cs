using Domain.IRepository;
using Domain.Models;

namespace DatabaseLayer.Repository
{
    public class MainQuestionRepository : BaseRepository<MainQuestion>, IMainQuestionRepository
    {
        public MainQuestionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<MainQuestion>> GetbyPatientId(Guid PatientId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsCreatBefor(MainQuestion x)
        {
            var S = await FindAllAsync(m => m.QuestionBody == x.QuestionBody && !m.IsDeleted);
            return S.Any();
        }
    }
}
