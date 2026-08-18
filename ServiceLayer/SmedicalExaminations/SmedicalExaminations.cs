using DatabaseLayer.Migrations;
using Domain.IUnitOfWork;
using Domain.Models;
using Domain.Response;
using ServiceLayer.Doctor.DTO;
using ServiceLayer.Prescription.DTO;
using ServiceLayer.SmedicalExaminations.DTO;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceLayer.SmedicalExaminations
{
    public class medicalExaminations : ImedicalExaminations
    {
        public IUnitOfWork unitOfWork;
        public medicalExaminations(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponse<IEnumerable<saveExaminationDTO1>>> GetByAppointmentIdAsync(Guid AppointmentId)
        {
            try
            {
                var data = await unitOfWork.saveExaminationsRepository.GetbyAppoitmentIDAsync(AppointmentId);
                foreach (var ii in data)
                {
                   ii.medicalExamination.classification = 
                         unitOfWork.ClassificationExaminationsRepository.GetById(ii.medicalExamination.classificationId);
                }
                
                 
                var doctors = await unitOfWork.doctorRepository.GetByIdsAsync(data.Select(m => new Guid(m.CreatedBy)).ToList());

                List<saveExaminationDTO1> dTO2s = new List<saveExaminationDTO1>();

                foreach (var i in data) 
                {
                    dTO2s.Add(new saveExaminationDTO1()
                    {
                        DoctorDTO = doctors.Where(m=> m.UserId == i.CreatedBy).First().ToDoctorDTO_1(),
                        id = i.Id,
                        idAppointment = i.AppointmentId,
                        idExamination = i.ExaminationId,
                        medicalExaminationsDTO = i.medicalExamination.ToMedicalExaminationsDTO1()
                    }
                    );
                }

                return new GeneralResponse<IEnumerable<saveExaminationDTO1>>()
                {
                    Data = dTO2s,
                    dateTime = DateTime.Now,
                    Message = "Save Data",
                    Success = true,
                };

            }
            catch (Exception ex)
            {
                return new GeneralResponse<IEnumerable<saveExaminationDTO1>>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = ex.Message,
                    Success = false,
                };
            }
        }

        public async Task<GeneralResponse<IEnumerable<medicalExaminationsDTO1>>> GetbySearchTerm(string SearchTerm)
        {
            try
            {
                var data = await unitOfWork.medicalExaminationsRepository.GetSearchTearmAsync(SearchTerm);
                return new GeneralResponse<IEnumerable<medicalExaminationsDTO1>>()
                {
                    Data = data.Select(m=> m.ToMedicalExaminationsDTO1()),
                    dateTime = DateTime.Now,
                    Message = "Save Data",
                    Success = true,
                };

            }
            catch (Exception ex) 
            {
                return new GeneralResponse<IEnumerable<medicalExaminationsDTO1>>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = ex.Message,
                    Success = false,
                };
            }
        }

        public async Task<GeneralResponse<saveExaminationDTO1>> saveExaminationAsync(saveExaminationDTO dTO , Guid Createby)
        {
            var xx = unitOfWork.saveExaminationsRepository.Find(m => m.ExaminationId == dTO.idExamination && m.AppointmentId == dTO.idAppointment);
            if (xx == null)
            {
                try
                {
                    var x = new Domain.Models.saveExamination()
                    {
                        AppointmentId = dTO.idAppointment,
                        ExaminationId = dTO.idExamination,
                    };

                    x.Create(Createby);
                    x = unitOfWork.saveExaminationsRepository.Add(x);
                    var m = await unitOfWork.SaveChangesAsync();
                    return new GeneralResponse<saveExaminationDTO1>()
                    {
                        Data = new saveExaminationDTO1()
                        {
                            id = x.Id,
                            idExamination = dTO.idExamination,
                            idAppointment = dTO.idAppointment
                        },
                        dateTime = DateTime.Now,
                        Message = "save is done",
                        Success = true,
                    };
                }
                catch (Exception ex)
                {

                    return new GeneralResponse<saveExaminationDTO1>()
                    {
                        Data = null,
                        Success = false,
                        Message = ex.Message
                    };
                }
            }else
            {
                return new GeneralResponse<saveExaminationDTO1>()
                {
                    Data = null,
                    Success = false,
                    Message = "you are save this item befor"
                };
            }

        }

    }
}