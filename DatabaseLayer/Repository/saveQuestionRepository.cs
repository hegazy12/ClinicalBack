using Domain.IRepository;
using Domain.Models;

namespace DatabaseLayer.Repository
{
    public class saveQuestionRepository : BaseRepository<saveQuestion>, IsaveQuestionRepository
    {
        public saveQuestionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sheet>> GetSheetsInAppointmentSaved(Guid Appointment)
        {
           var C = _context.saveQuestions.Where(m => m.AppointmentId == Appointment && !m.IsDeleted).Select(m => m.SheetId).Distinct();
           var x = _context.sheets.Where(m => C.Contains(m.Id)).ToList();
         
           return x;
        }

        public async Task<bool> IsCreatBefor(saveQuestion x)
        {
            var S = await FindAllAsync(m => m.AppointmentId == x.AppointmentId && m.QuestionId == m.QuestionId && !m.IsDeleted);
            if (S.Count() > 0)
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
