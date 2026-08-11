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


        public Task<List<medicalExamination>> GetbyIdsAsync(List<Guid> guids)
        {
            throw new NotImplementedException();
        }

        public Task<List<medicalExamination>> GetSearchTearmAsync(string SearchTearm)
        {
            throw new NotImplementedException();
        }
    }
}
