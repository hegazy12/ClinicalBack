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

    public async Task<GeneralResponse<IEnumerable<RgistrationDTO>>> GetList()
    {
        var users = await _unitOfWork.AppUserRepository.GetAll();

        var userDtos = users.Select(u => new RgistrationDTO
        {
            Id = u.Id,
            UserName = u.UserName,
            Email = u.Email,
            FirstName = u.FirstName,
            LastName = u.LastName,
            jobTitle = u.jobTitle
        });

        return new GeneralResponse<IEnumerable<RgistrationDTO>>
        {
            Success = true,
            Data = userDtos.ToList()
        };

    }


    public async Task<GeneralResponse<IEnumerable<RoleDTO>>> GetRoles()
    {
        var roles = await _unitOfWork.AppUserRepository.GetRoleAsync();

        return new GeneralResponse<IEnumerable<RoleDTO>>
        {
            Success = true,
            Data = roles.Select(r => new RoleDTO
            {
                Id = r.Id,
                Name = r.Name ?? string.Empty
            }).ToList()
        };
    }

    public async Task<GeneralResponse<ReturnRgistrationDTO>> RegisterAsync(RgistrationDTO_0 DTO)
    {
        var existingUserByUsername = await _unitOfWork.AppUserRepository.GetByUsernameAsync(DTO.UserName);
        var existingUserByEmail = await _unitOfWork.AppUserRepository.GetByEmailAsync(DTO.Email);

        if (existingUserByUsername != null || existingUserByEmail != null)
        {
            throw new Exception("Username or email already exists.");
        }

        // No roles requested -> default role. Every requested role must exist.
        var requestedRoles = DTO.Roles.Where(r => !string.IsNullOrWhiteSpace(r)).Distinct().ToList();
        if (requestedRoles.Count == 0)
        {
            requestedRoles.Add("BaseUser");
        }

        var existingRoles = (await _unitOfWork.AppUserRepository.GetRoleAsync()).Select(r => r.Name).ToList();
        var unknownRoles = requestedRoles.Where(r => !existingRoles.Contains(r)).ToList();
        
        if (unknownRoles.Count > 0)
        {
            return new GeneralResponse<ReturnRgistrationDTO>
            {
                Success = false,
                Data = null,
                Message = $"Unknown role(s): {string.Join(", ", unknownRoles)}"
            };
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
            foreach (var role in requestedRoles)
            {
                await _unitOfWork.AppUserRepository.AddRoleAsync(Convert.ToString(createdUser.Data.Id), role);
            }
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
                        Roles     = requestedRoles
                    }
            };
        }
    }

  
}
