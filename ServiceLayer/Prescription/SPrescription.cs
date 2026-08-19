using Domain.IUnitOfWork;
using Domain.Models;
using Domain.Response;
using ServiceLayer.Doctor.DTO;
using ServiceLayer.Drug.Dtos;
using ServiceLayer.Prescription.DTO;
using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Text;

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
            var xx = unitOfWork.prescriptionRepository.Find(m => m.DrugId == prescription.DrugId && prescription.AppointmentId == m.AppointmentId);
            if (xx == null)
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
                    await unitOfWork.SaveChangesAsync();
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
                            from = p.from,
                            to = p.to,
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
            else
            {
                return new GeneralResponse<PrescriptionDTO1>()
                {
                    dateTime = DateTime.Now,
                    Success = false,
                    Message = "Prescription is created befor",
                    Data = null
                };
            }
        }

        public Task<GeneralResponse<bool>> DeletePrescriptionAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<GeneralResponse<IEnumerable<PrescriptionDTO2>>> GetByAppoinmentAsync(Guid id)
        {
            List<Domain.Models.Prescription> prescriptions =
                (List<Domain.Models.Prescription>) await unitOfWork.prescriptionRepository.GetByAppointmentIdAsync(id);

            var mm = await unitOfWork.doctorRepository.GetByIdsAsync(prescriptions.Select(m=> new Guid(m.CreatedBy)).ToList());

            var d = await unitOfWork.DrugRepository.GetbyIdsasync(prescriptions.Select(m => m.DrugId).ToList());

            List<PrescriptionDTO2> dTO2s = new List<PrescriptionDTO2>();
            
            foreach (var i in prescriptions)
            {
                dTO2s.Add(new PrescriptionDTO2()
                {
                    id = i.Id,
                    doctor = mm.Where(m => m.UserId == i.CreatedBy).First().ToDoctorDTO_1(),
                    AppointmentId = i.AppointmentId,
                    DrugId = i.DrugId,
                    Frequency = i.Frequency,
                    Notes = i.Notes,
                    from = i.from,
                    to = i.to,
                    type = i.type,
                    drug = d.Where(m => m.Id == i.DrugId).First().ToDrugDto()
                });
                //i.Drug = d.Where(m => m.Id == i.DrugId).First();
                //i.ToPrescriptionDTO2();

            }

            return new GeneralResponse<IEnumerable<PrescriptionDTO2>>
            {
                Success = true,
                Data = dTO2s
            };

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