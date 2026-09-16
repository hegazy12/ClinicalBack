using Domain.Response;
using ServiceLayer.ExaminationFindingService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ExaminationFindingService
{
    public interface IExaminationFindingService
    {
        public Task<GeneralResponse<ExaminationFindingDTO1>> Add(ExaminationFindingDTO DTO, Guid CreateBy);
        public Task<GeneralResponse<Boolean>> Delete(Guid ID, Guid CreateBy);
        public Task<GeneralResponse<IEnumerable<ExaminationFindingDTO1>>> GetAll();

        public Task<GeneralResponse<IEnumerable<ExaminationFindingDTO1>>> GetSearchTearmAsync(string SearchTearm);
    }
}
