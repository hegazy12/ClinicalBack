using Domain.DTO;
using Domain.IUnitOfWork;
using Domain.Models;
using Domain.Response;
using ServiceLayer.Doctor.DTO;
using ServiceLayer.SmedicalExaminations.DTO;
using System.Collections.Immutable;

namespace ServiceLayer.SmedicalExaminations
{
    public class medicalExaminations : ImedicalExaminations
    {
        public IUnitOfWork unitOfWork;
     
        public medicalExaminations(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<GeneralResponse<saveExaminationDTO1>> Delete(Guid id, Guid userid)
        {
            try
            {
                var saveExaminations = unitOfWork.saveExaminationsRepository.Find(m => m.Id == id);
                saveExaminations.MarkAsDeleted(userid);
                unitOfWork.saveExaminationsRepository.Update(saveExaminations);
                await unitOfWork.SaveChangesAsync();
                return new GeneralResponse<saveExaminationDTO1>()
                {
                    Data = saveExaminations.TosaveExaminationDTO1(),
                    dateTime = DateTime.Now,
                    Message = "The data was successfully completed",
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<saveExaminationDTO1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = ex.Message,
                    Success = false,
                };
            }
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
                        last = i.last,
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
                    Message = "The data was successfully completed",
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
            var xx = unitOfWork.saveExaminationsRepository.Find(m => m.ExaminationId == dTO.idExamination && m.AppointmentId == dTO.idAppointment && m.last == dTO.last 
            && m.IsDeleted == false && m.last == dTO.last);
            if (xx == null)
            {
                try
                {
                    var x = new Domain.Models.saveExamination()
                    {
                        AppointmentId = dTO.idAppointment,
                        ExaminationId = dTO.idExamination,
                        last =dTO.last
                    };

                    x.Create(Createby);
                    
                   // x.ExaminationPhotos = new List<string>();

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

        public async Task<GeneralResponse<string>> uploadPhoto(Guid IdExamination, Guid CreateBy ,UploadPhotoRequest request, string uploadsRootPath)
        {
            if (string.IsNullOrEmpty(request.PhotoBase64))
            {
                return new GeneralResponse<string>
                {
                    Success = false,
                    Message = "No photo provided.",
                    Data = null
                };
            }

            try
            {
                var Examination = unitOfWork.saveExaminationsRepository.GetById(IdExamination);
                
                var commaIndex = request.PhotoBase64.IndexOf(",");
                var base64Data = commaIndex >= 0
                    ? request.PhotoBase64.Substring(commaIndex + 1)
                    : request.PhotoBase64;

                var imageBytes = Convert.FromBase64String(base64Data);
                var fileName = $"exam_{IdExamination}_{Guid.NewGuid()}.png";
                var folderPath = Path.Combine(uploadsRootPath , "Uploads" , "MedicalExaminations");
                Directory.CreateDirectory(folderPath);
                var filePath = Path.Combine(folderPath, fileName);
                await File.WriteAllBytesAsync(filePath, imageBytes);
                saveExaminationPhotos photo = new saveExaminationPhotos()
                {
                    examinationId = IdExamination,
                    photoPath = filePath,
                    photoBase64 = request.PhotoBase64,
                    imageBytes = imageBytes
                };
                photo.Create(CreateBy); 
                unitOfWork.examinationPhotoRepository.Add(photo);
                await unitOfWork.SaveChangesAsync();

                return new GeneralResponse<string>
                {
                    Success = true,
                    Message = "Photo uploaded successfully.",
                    Data = fileName
                };
            }
            catch (FormatException)
            {
                return new GeneralResponse<string>
                {
                    Success = false,
                    Message = "Invalid base64 image data.",
                    Data = null
                };
            }
        }
    }
}