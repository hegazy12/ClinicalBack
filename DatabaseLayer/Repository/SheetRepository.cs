using Domain.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DatabaseLayer.Repository
{
    public class SheetRepository : BaseRepository<Sheet>, ISheetRepository
    {
        public SheetRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sheet>> GetByPtinetId(Guid patientid)
        {
            var toYear = DateOnly.FromDateTime(DateTime.Today).Year;

            var P = _context.Patients.Where(m => m.Id == patientid).Select(m => new { age = toYear - m.DateOfBirth.Year, Gendar = (m.gender == "Male") ? 1 : 2 }).First();
            var sheets = _context.sheets.Where(m => !m.IsDeleted && (m.Gendar == 0 || m.Gendar == P.Gendar) && P.age > m.minage && m.maxage > P.age ).ToList();

            var q = _context.sheets.Where(m => !m.IsDeleted && (m.Gendar == 0 || m.Gendar == P.Gendar) && P.age > m.minage && m.maxage > P.age);
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine(q.ToQueryString());
            Console.WriteLine("_________________________________________________________");

            return sheets;
        }

        public async Task<bool> IsSavedBefor(Sheet Sheet)
        {
            var x = await FindAllAsync(m=> m.Name == Sheet.Name && !m.IsDeleted);
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