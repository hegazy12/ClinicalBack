using Domain.IUnitOfWork;
using Domain.Response;
using ServiceLayer.Prescription.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace ServiceLayer.Prescription
{
    public class SPrescription : ISPrescription
    {
        public IUnitOfWork unitOfWork;

        public SPrescription(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<GeneralResponse<PrescriptionDTO1>> CreatePrescriptionAsync(PrescriptionDTO prescription, Guid userId)
        {
            Domain.Models.Prescription pres = new Domain.Models.Prescription()
            {
                AppointmentId = prescription.AppointmentId,
                DrugId = prescription.DrugId,
                Frequency = prescription.Frequency,
                from = prescription.from,
                to = prescription.to,
                Notes = prescription.Notes,
                type = prescription.type,
            };
            pres.Create(userId);
            try
            {
                var p = await unitOfWork.prescriptionRepository.CreateAsync(pres);
                return new GeneralResponse<PrescriptionDTO1>()
                {
                    dateTime = DateTime.Now,
                    Success = true,
                    Message = "Prescription created successfully.",
                    Data = new PrescriptionDTO1()
                    {
                        AppointmentId = p.AppointmentId,
                        DrugId = p.DrugId,
                        Frequency = p.Frequency,
                        from =p.from,
                        to =p.to,
                        id = p.Id,
                        Notes = p.Notes,
                        type = p.type,
                    }
                };
            }
            catch (Exception ex) 
            {
                return new GeneralResponse<PrescriptionDTO1>()
                {
                    dateTime = DateTime.Now,
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
            }
           
        }

        public Task<GeneralResponse<bool>> DeletePrescriptionAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<PrescriptionDTO1>> GetPrescriptionByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<IEnumerable<PrescriptionDTO1>>> ListPrescriptionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<PrescriptionDTO1>> UpdatePrescriptionAsync(Guid id, PrescriptionDTO prescription)
        {
            throw new NotImplementedException();
        }
    }
}
