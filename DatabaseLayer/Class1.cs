using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer
{
    public class Class1 : classinter
    {
        private readonly AppDbContext _context;
        public Class1(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Test>> GetAllTests()
        {
            return await _context.Tests.ToListAsync();
        }
    }
}
