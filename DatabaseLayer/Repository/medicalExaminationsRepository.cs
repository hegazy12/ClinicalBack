using DatabaseLayer.Migrations;
using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class medicalExaminationsRepository : BaseRepository<medicalExamination>, ImedicalExaminationsRepository
    {
        public medicalExaminationsRepository(AppDbContext context) : base(context)
        {

        }

        public Task<IEnumerable<medicalExamination>> GetbyIdsAsync(List<Guid> guids)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<medicalExamination>> GetSearchTearmAsync(string SearchTearm)
        {
          return  await FindAllAsync(m => m.nameEn.Contains(SearchTearm), new string[] { "classification" });
        }
    }
}
