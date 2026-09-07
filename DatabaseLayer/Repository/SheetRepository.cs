using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class SheetRepository : BaseRepository<Sheet>, ISheetRepository
    {
        public SheetRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsSavedBefor(Sheet Sheet)
        {
            var x = await FindAllAsync(m=> m.Name == Sheet.Name);
            if (x.Count() > 0)
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