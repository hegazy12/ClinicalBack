using DatabaseLayer.Migrations;
using Domain.IUnitOfWork;
using Domain.Models;
using Domain.Response;
using ServiceLayer.DiagnosService.DTO;
using ServiceLayer.SmedicalExaminations.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceLayer.DiagnosService
{
    public class DiagnosService : IDiagnosService
    {
        public IUnitOfWork unitOfWork;
        public DiagnosService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponse<DiagnosDTO_2>> Add(CreateDiagnosDTO dTO, Guid Createby)
        {
            try
            {
                var v = unitOfWork.diagnosMasterRepository.FindAll(m => m.Name == dTO.Name && m.IsDeleted == false);
              
                if (v.Count() == 0)
                {
                    DiagnosMaster diagnosMaster = new DiagnosMaster()
                    {
                        Name = dTO.Name,
                        Code = "NA",
                    };

                    diagnosMaster.Create(Createby);
                    
                    Domain.Models.Diagnos  diagnos = new Domain.Models.Diagnos()
                    {
                        AppointmentId = dTO.AppointmentId,
                        Notes = dTO.Note,
                        DiagnosMasterId = diagnosMaster.Id,
                        DiagnosMaster = diagnosMaster
                    };

                    diagnos.Create(Createby);
                    unitOfWork.diagnosMasterRepository.Add(diagnosMaster);
                    unitOfWork.diagnosRepository.Add(diagnos);
                    var reaslt =  await unitOfWork.SaveChangesAsync();

                    if (reaslt > 0) 
                    {
                        return new GeneralResponse<DiagnosDTO_2>()
                        {
                            Data = diagnos.ToDiagnosDTO_2(),
                            dateTime = DateTime.Now,
                            Message = "The data was successfully completed",
                            Success = true,
                        };
                    }
                    else
                    {

                        return new GeneralResponse<DiagnosDTO_2>()
                        {
                            Data = null,
                            dateTime = DateTime.Now,
                            Message = "it same sing wrong done with in save",
                            Success = false,
                        };
                    }
                }
                else
                {
                   
                    var vv = unitOfWork.diagnosRepository.FindAll(m => m.Notes == dTO.Note && m.AppointmentId == dTO.AppointmentId && m.DiagnosMasterId == v.First().Id);
                    if (vv.Count() == 0)
                    {
                        Domain.Models.Diagnos diagnos = new Domain.Models.Diagnos()
                        {
                            AppointmentId = dTO.AppointmentId,
                            Notes = dTO.Note,
                            DiagnosMasterId = v.First().Id,
                        };
                        diagnos.Create(Createby);
                        unitOfWork.diagnosRepository.Add(diagnos);
                        var reaslt = await unitOfWork.SaveChangesAsync();

                        return new GeneralResponse<DiagnosDTO_2>()
                        {
                            Data = diagnos.ToDiagnosDTO_2(),
                            dateTime = DateTime.Now,
                            Message = "The data was successfully completed",
                            Success = true,
                        };
                    }
                    else
                    {
                        return new GeneralResponse<DiagnosDTO_2>()
                        {
                            Data = null,
                            dateTime = DateTime.Now,
                            Message = "The data was saved before",
                            Success = false,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GeneralResponse<DiagnosDTO_2>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = ex.Message,
                    Success = false,
                };
            }
        }

        public async Task<GeneralResponse<DiagnosDTO_2>> Delete(Guid diagnosID, Guid userid)
        {
            try
            {
                var diagnos = unitOfWork.diagnosRepository.Find(m => m.Id == diagnosID);
                diagnos.MarkAsDeleted(userid);
                unitOfWork.diagnosRepository.Update(diagnos);
                await unitOfWork.SaveChangesAsync();
                return new GeneralResponse<DiagnosDTO_2>()
                {
                    Data = diagnos.ToDiagnosDTO_2(),
                    dateTime = DateTime.Now,
                    Message = "The data was successfully completed",
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<DiagnosDTO_2>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = ex.Message,
                    Success = false,
                };
            }
        }

        public async Task<GeneralResponse<IEnumerable<DiagnosDTO_2>>> GetbyAppoitmentID(Guid appoitmentID)
        {
            var data = await this.unitOfWork.diagnosRepository.GetByAppointmentIdAsync(appoitmentID);

            return new GeneralResponse<IEnumerable<DiagnosDTO_2>>()
            {
                Data = data.Select(d => d.ToDiagnosDTO_2()),
                dateTime = DateTime.Now,
                Message = "The data was successfully completed",
                Success = true
            };
        }

        public async Task<GeneralResponse<IEnumerable<MasterDiagnosDTO_1>>> GetbySearchTerm(string SearchTerm)
        { 
            try
            {
                var data = await unitOfWork.diagnosMasterRepository.GetSearchTearmAsync(SearchTerm);
                return new GeneralResponse<IEnumerable<MasterDiagnosDTO_1>>()
                {
                    Data = data.Select(m => m.ToMasterDiagnosDTO_1()),
                    dateTime = DateTime.Now,
                    Message = "The data was successfully completed",
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<IEnumerable<MasterDiagnosDTO_1>>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = ex.Message,
                    Success = false,
                };
            }
        }
   }
}
