using Domain.Models;
using Domain.IUnitOfWork;
using Domain.Response;
using SericeLayer.Account.Rgistration.DTO;
using ServiceLayer.JWT;


namespace SericeLayer.Account.Rgistration;

public class Rgistration : IRgistration
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IJWTModule _jwtModule;

    public Rgistration(IUnitOfWork unitOfWork, IJWTModule jwtModule)
    {
        _unitOfWork = unitOfWork;
        _jwtModule = jwtModule;
    }

    public async Task<GeneralResponse<ReturnRgistrationDTO>> RegisterAsync(RgistrationDTO_0 DTO)
    {
            var existingUserByUsername = await _unitOfWork.AppUserRepository.GetByUsernameAsync(DTO.UserName);
            var existingUserByEmail = await _unitOfWork.AppUserRepository.GetByEmailAsync(DTO.Email);

            if (existingUserByUsername != null || existingUserByEmail != null)
            {
                throw new Exception("Username or email already exists.");
            }
        
            ApplicationUser user = new ApplicationUser
            {
                UserName  = DTO.UserName,
                Email     = DTO.Email,
                FirstName = DTO.FirstName,
                LastName  = DTO.LastName,
                jobTitle  = DTO.jobTitle
            };
       
            var createdUser = await _unitOfWork.AppUserRepository.CreateAsync(user, DTO.Password);
            
            if (!createdUser.Success)
            {
                return new GeneralResponse<ReturnRgistrationDTO>
                {
                    Success = false,
                    Data = null,
                    Errors = createdUser.Errors,
                    Message = createdUser.Message
                };
            }
            else
            {
                await _unitOfWork.AppUserRepository.AddRoleAsync(Convert.ToString(createdUser.Data.Id), "BaseUser");
                return new GeneralResponse<ReturnRgistrationDTO>
                    {
                        Success = true,
                        Data = new ReturnRgistrationDTO
                        {
                            Id        = Convert.ToString(createdUser.Data.Id),
                            UserName  = createdUser.Data.UserName,
                            Email     = createdUser.Data.Email,
                            FirstName = createdUser.Data.FirstName,
                            LastName  = createdUser.Data.LastName,
                            jobTitle  = createdUser.Data.jobTitle,
                            Token     = _jwtModule.GenerateToken(new Guid(createdUser.Data.Id), createdUser.Data.UserName, createdUser.Data.Email),
                            Roles     = new List<string> { "BaseUser" }
                        }
                };
            }
    }

}
