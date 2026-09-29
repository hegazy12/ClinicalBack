using Domain.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer.Repository
{
    public class MainQuestionRepository : BaseRepository<MainQuestion>, IMainQuestionRepository
    {

        public MainQuestionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MainQuestion>> GetbyPatientId(Guid PatientId)
        {
            var toYear = DateOnly.FromDateTime(DateTime.Today).Year;
            var MM = _context.saveMainQuestions.Where(m => m.PatientId == PatientId && !m.IsDeleted).Select(m => m.MainQuestionId);
            
            var P = _context.Patients.Where(m => m.Id == PatientId).Select(m=> new { age = toYear - m.DateOfBirth.Year , Gendar = (m.gender == "Male") ? 1 : 2}).First();
            
            var CC = await _context.mainQuestions.Where(m => !MM.Contains(m.Id) &&  ( m.Gendar == 0 || m.Gendar == P.Gendar ) && m.maxage > P.age && m.minage < P.age && !m.IsDeleted).ToListAsync();

            return CC;
        }

        public async Task<bool> IsCreatBefor(MainQuestion x)
        {
            var S = await FindAllAsync(m => m.QuestionBody == x.QuestionBody && !m.IsDeleted);
            return S.Any();
        }

    }
}
