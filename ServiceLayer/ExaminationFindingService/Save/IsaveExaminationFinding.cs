using Domain.Response;
using ServiceLayer.ExaminationFindingService.DTO;
using ServiceLayer.ExaminationFindingService.Save.DTO;
using ServiceLayer.SmedicalExaminations.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ExaminationFindingService.Save
{
    public interface IsaveExaminationFinding
    {
        public Task<GeneralResponse<saveExaminationFindingDTO1>> Add(saveExaminationFindingDTO DTO, Guid CreateBy);
        public Task<GeneralResponse<Boolean>> Delete(Guid ID, Guid CreateBy);
        public Task<GeneralResponse<IEnumerable<saveExaminationFindingDTO2>>> GetByAppointmentIdAsync(Guid Appointment);
    }
}
