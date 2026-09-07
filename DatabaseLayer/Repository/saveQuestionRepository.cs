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
    }
}
