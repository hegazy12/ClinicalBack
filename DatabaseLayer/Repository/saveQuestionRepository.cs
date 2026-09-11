using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class saveQuestionRepository : BaseRepository<saveQuestion>, IsaveQuestionRepository
    {
        public saveQuestionRepository(AppDbContext context) : base(context)
        {
            _context = context;
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
