using Domain.IUnitOfWork;
using ServiceLayer.Doctor.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Response;

namespace ServiceLayer.Doctor
{
    public class SDoctor : ISDoctor
    {
        public IUnitOfWork unitOfWork;
        public SDoctor(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<GeneralResponse<DoctorDTO_1>> addDoctor(DoctorDTO_0 doctor, Guid createdBy)
        {
            static GeneralResponse<DoctorDTO_1> Fail(string message) => new GeneralResponse<DoctorDTO_1>()
            {
                Data = null,
                Message = message,
                dateTime = DateTime.Now,
                Success = false
            };

            if (doctor == null || string.IsNullOrWhiteSpace(doctor.UserId) || string.IsNullOrWhiteSpace(doctor.Specialization))
            {
                return Fail("User id and specialization are required.");
            }

            try
            {
                var user = await unitOfWork.AppUserRepository.GetUserIdAsync(doctor.UserId);
                if (user == null)
                {
                    return Fail("User not found.");
                }

                var alreadyDoctor = await unitOfWork.doctorRepository.FindAllAsync(d => d.UserId == user.Id && !d.IsDeleted);
                if (alreadyDoctor.Any())
                {
                    return Fail("This user is already registered as a doctor.");
                }

                var entity = doctor.ToDoctor();
                entity.UserId = user.Id;
                entity.Specialization = doctor.Specialization.Trim();
                entity.Create(createdBy);

                await unitOfWork.doctorRepository.addDoctor(entity);
                await unitOfWork.SaveChangesAsync();

                entity.ApplicationUser = user;
                var result = entity.ToDoctorDTO_1();
                result.UserId = user.Id;

                return new GeneralResponse<DoctorDTO_1>()
                {
                    Data = result,
                    Message = "Doctor created successfully.",
                    dateTime = DateTime.Now,
                    Success = true
                };
            }
            catch (Exception)
            {
                return Fail("Failed to save the doctor.");
            }
        }

        public Task<GeneralResponse<DoctorDTO_1>> deleteDoctor(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<GeneralResponse<IEnumerable<string>>> GetAllSpecialization()
        {
            var x = await unitOfWork.doctorRepository.GetSpecializationsAsync();
            var  m = x.Select(m => m.SpecializationName);
            return new GeneralResponse<IEnumerable<string>>()
            {
                Data = m,
                Message = "Specialization retrieved successfully.",
                dateTime = DateTime.Now,
                Success = false
            };

        }

        public async Task<GeneralResponse<DoctorDTO_1>> GetDoctor(Guid id)
        {
            try
            {
                var entity = await unitOfWork.doctorRepository.GetDoctor(id);
                if (entity == null)
                {
                    return new GeneralResponse<DoctorDTO_1>()
                    {
                        Data = null,
                        Message = "Doctor not found.",
                        dateTime = DateTime.Now,
                        Success = false
                    };
                }

                var result = entity.ToDoctorDTO_1();
                result.UserId = entity.UserId ?? string.Empty;

                return new GeneralResponse<DoctorDTO_1>()
                {
                    Data = result,
                    Message = "Doctor retrieved successfully.",
                    dateTime = DateTime.Now,
                    Success = true
                };
            }
            catch (Exception)
            {
                return new GeneralResponse<DoctorDTO_1>()
                {
                    Data = null,
                    Message = "Failed to retrieve the doctor.",
                    dateTime = DateTime.Now,
                    Success = false
                };
            }
        }

        public async Task<GeneralResponse<IEnumerable<DoctorDTO_1>>> GetDoctors()
        {
            try
            {
                var doctors = await unitOfWork.doctorRepository.GetDoctors();
                
                return new GeneralResponse<IEnumerable<DoctorDTO_1>>()
                {
                    Success = true,
                    Data = doctors.Select(d => d.ToDoctorDTO_1()),
                    Message = "Doctors retrieved successfully."
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<IEnumerable<DoctorDTO_1>>()
                {
                    Data = null,
                    Message= ex.Message,
                    dateTime = DateTime.Now,
                    Success=false
                };
            }
        }

        public Task<GeneralResponse<IEnumerable<DoctorDTO_1>>> GetDoctorsBySpecialization(string specialization)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<DoctorDTO_1>> updateDoctor(DoctorDTO_1 doctor)
        {
            throw new NotImplementedException();
        }

      
    }
}
