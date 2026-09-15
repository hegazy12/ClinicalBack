using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IQuestionRepository : IBaseRepository<Question>
    {
        public Task<Boolean> IsCreatBefor(Question x);
        public Task<IEnumerable<Question>> GetbySheetId(Guid sheetId, Guid AppointmentId);

    }
}
