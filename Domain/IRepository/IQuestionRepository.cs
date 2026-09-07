using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IQuestionRepository : IBaseRepository<Question>
    {
       //public Task<Question> GetById(int id);

    }
}
