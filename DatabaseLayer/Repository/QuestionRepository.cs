using Domain.IRepository;
using Domain.Models;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer.Repository
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {

        public QuestionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>>  GetbySheetId(Guid sheetId, Guid appointmentId)
        {
            var answeredQuestionIds = _context.saveQuestions
                .Where(m => m.SheetId == sheetId && m.AppointmentId == appointmentId && !m.IsDeleted)
                .Select(m => m.QuestionId);

            var unansweredQuestions = await _context.questions
                .Where(m => m.SheetId == sheetId && !m.IsDeleted &&  !answeredQuestionIds.Contains(m.Id))
                .ToListAsync();

            return unansweredQuestions;
        }

        public async Task<bool> IsCreatBefor(Question x)
        {
            var S = await FindAllAsync(m => m.SheetId == x.SheetId && m.QuestionBody == x.QuestionBody && !m.IsDeleted);
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
