using Domain.Response;
using ServiceLayer.cheifComplaneService.DTO;
using ServiceLayer.SheetService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.cheifComplaneService
{
    public interface IcheifComplaneService
    {
        public Task<GeneralResponse<chiefComplaintDTO1>> save(chiefComplaintDTO chiefComplaintDTO, Guid userId);
        public Task<GeneralResponse<Boolean>> Delete(Guid chiefComplaintId, Guid userId);
        public Task<GeneralResponse<IEnumerable<chiefComplaintDTO1>>> GetbyAppointmentId(Guid id);
    }
}
