using Domain.IUnitOfWork;
using Domain.Response;
using ServiceLayer.SmedicalExaminations.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.SmedicalExaminations
{
    public class medicalExaminations : ImedicalExaminations
    {
        public IUnitOfWork unitOfWork;
        public medicalExaminations(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<GeneralResponse<medicalExaminationsDTO>> GetbySearchTerm(string SearchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
