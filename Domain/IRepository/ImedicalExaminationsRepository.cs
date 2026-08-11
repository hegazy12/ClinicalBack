using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface ImedicalExaminationsRepository : IBaseRepository<medicalExamination>
    {

      
        public Task<List<medicalExamination>> GetbyIdsAsync(List<Guid> guids);
        public Task<List<medicalExamination>> GetSearchTearmAsync(string SearchTearm);

    }
}
