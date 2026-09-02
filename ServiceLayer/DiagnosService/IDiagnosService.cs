using Domain.Response;
using ServiceLayer.DiagnosService.DTO;
using ServiceLayer.SmedicalExaminations.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.DiagnosService
{
    public interface IDiagnosService
    {
        public Task<GeneralResponse<IEnumerable<MasterDiagnosDTO_1>>> GetbySearchTerm(string SearchTerm);
        public Task<GeneralResponse<DiagnosDTO_2>> Add(CreateDiagnosDTO dTO, Guid Createby);
        public Task<GeneralResponse<IEnumerable<DiagnosDTO_2>>> GetbyAppoitmentID(Guid appoitmentID);
        public Task<GeneralResponse<DiagnosDTO_2>> Delete(Guid diagnosID, Guid userid);
    }
}
