using Domain.Models;
using Domain.IUnitOfWork;
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

    public async Task<ReturnRgistrationDTO> RegisterAsync(RgistrationDTO_0 DTO)
    {
        // Check if the username or email already exists
        var existingUserByUsername = await _unitOfWork.AppUserRepository.GetByUsernameAsync(DTO.UserName);
        var existingUserByEmail = await _unitOfWork.AppUserRepository.GetByEmailAsync(DTO.Email);

        if (existingUserByUsername != null || existingUserByEmail != null)
        {
            throw new Exception("Username or email already exists.");
        }
        
        ApplicationUser user = new ApplicationUser
        {
            UserName = DTO.UserName,
            Email = DTO.Email,
            FirstName = DTO.FirstName,
            LastName = DTO.LastName,
            jobTitle = DTO.jobTitle
        };
        try
        {
            var createdUser = await _unitOfWork.AppUserRepository.CreateAsync(user, DTO.Password);
            await _unitOfWork.AppUserRepository.AddRoleAsync(createdUser.Id, "BaseUser");
            
            return new ReturnRgistrationDTO
            {
                Id = createdUser.Id,
                UserName = createdUser.UserName,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                jobTitle = createdUser.jobTitle,
                Token = _jwtModule.GenerateToken(Guid.Parse(createdUser.Id), createdUser.UserName, createdUser.Email),
                Roles = new List<string> { "BaseUser" }
            };
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while creating the user.", ex);
        }
    }

}
