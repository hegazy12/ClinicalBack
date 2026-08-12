using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface ImedicalExaminationsRepository : IBaseRepository<medicalExamination>
    { 
        public Task<IEnumerable<medicalExamination>> GetbyIdsAsync(List<Guid> guids);
        public Task<IEnumerable<medicalExamination>> GetSearchTearmAsync(string SearchTearm);
      //  public Task<IEnumerable<medicalExamination>> GetByAppointmentId(Guid guid);
    }
}
