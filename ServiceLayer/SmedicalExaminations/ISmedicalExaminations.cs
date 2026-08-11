using System;
using System.Collections.Generic;
using System.Text;
using ServiceLayer.SmedicalExaminations.DTO;

using Domain.Response;

namespace ServiceLayer.SmedicalExaminations
{
    public interface ImedicalExaminations
    {
        public Task<GeneralResponse<medicalExaminationsDTO>> GetbySearchTerm(string SearchTerm);

    }
}
