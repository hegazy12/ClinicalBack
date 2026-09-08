using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(AppDbContext context) : base(context)
        {
            _context = context;
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
