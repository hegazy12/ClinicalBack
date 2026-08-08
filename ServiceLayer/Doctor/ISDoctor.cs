using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Response;

namespace ServiceLayer.Doctor
{
    public interface ISDoctor
    {
        public Task<GeneralResponse<DTO.DoctorDTO_1>> GetDoctor(Guid id);
        public Task<GeneralResponse<IEnumerable<DTO.DoctorDTO_1>>> GetDoctors();
        public Task<GeneralResponse<IEnumerable<DTO.DoctorDTO_1>>> GetDoctorsBySpecialization(string specialization);
        public Task<GeneralResponse<DTO.DoctorDTO_1>> addDoctor(DTO.DoctorDTO_1 doctor);
        public Task<GeneralResponse<DTO.DoctorDTO_1>> updateDoctor(DTO.DoctorDTO_1 doctor);
        public Task<GeneralResponse<DTO.DoctorDTO_1>> deleteDoctor(Guid id);
    }
}
