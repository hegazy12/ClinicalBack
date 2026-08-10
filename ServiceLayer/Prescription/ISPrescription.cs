using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using ServiceLayer.Prescription.DTO;
using Domain.Response;

namespace ServiceLayer.Prescription
{
    public interface ISPrescription
    {
        public Task<GeneralResponse<PrescriptionDTO1>> GetPrescriptionByIdAsync(Guid id);
        public Task<GeneralResponse<IEnumerable<PrescriptionDTO1>>> ListPrescriptionsAsync();
        public Task<GeneralResponse<PrescriptionDTO1>> CreatePrescriptionAsync(PrescriptionDTO prescription, Guid userId);
        public Task<GeneralResponse<PrescriptionDTO1>> UpdatePrescriptionAsync(Guid id, PrescriptionDTO prescription);
        public Task<GeneralResponse<bool>> DeletePrescriptionAsync(Guid id);

        public Task<GeneralResponse<IEnumerable<PrescriptionDTO2>>> GetByAppoinmentAsync(Guid id);
      //  public Task<GeneralResponse<IEnumerable<PrescriptionDTO1>>> GetByAppoinmentAsync(Guid id);
    }
}
