using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class ClassificationExaminationsRepository : BaseRepository<classificationMedicalExamination>, IClassificationExaminationsRepository
    {
        public ClassificationExaminationsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
