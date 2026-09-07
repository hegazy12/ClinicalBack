using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface ISheetRepository : IBaseRepository<Sheet>
    {
        public Task<Boolean> IsSavedBefor(Sheet Sheet);

    }
}
