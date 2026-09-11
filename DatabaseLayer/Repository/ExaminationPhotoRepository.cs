using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class ExaminationPhotoRepository : BaseRepository<saveExaminationPhotos>, IExaminationPhotoRepository
    {
        public ExaminationPhotoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
