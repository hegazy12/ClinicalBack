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
        public Task<GeneralResponse<DoctorDTO_1>> addDoctor(DoctorDTO_1 doctor)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<DoctorDTO_1>> deleteDoctor(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<DoctorDTO_1>> GetDoctor(Guid id)
        {
            throw new NotImplementedException();
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
