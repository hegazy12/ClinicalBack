using SericeLayer.Account.Login.DTO;
using Domain.IUnitOfWork;
using ServiceLayer.JWT;
using Domain.Response;
using System.ComponentModel.DataAnnotations;

namespace SericeLayer.Account.Login;

public class Login : ILogin
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJWTModule _jwtService;
    public Login(IUnitOfWork unitOfWork, IJWTModule jwtService)
    {
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
    }

    public async Task<GeneralResponse<ReturnLoginDTO>> LoginAsync(LoginDTO loginDto)
    {
        var user = await _unitOfWork.AppUserRepository.GetByUsernameAsync(loginDto.UserName);
        if (user == null)
        {
            var E = new Dictionary<string, List<string>>();
            E.Add("Username", new List<string> { "username is not valid" });
            return await Task.FromResult(new GeneralResponse<ReturnLoginDTO> { Success = false, Errors = E, Message = "username is not valid" });
        }

        var passwordValid = await _unitOfWork.AppUserRepository.CheckPasswordAsync(user, loginDto.Password);
   
        if (!passwordValid)
        {
            var E = new Dictionary<string, List<string>>();
            E.Add("Password", new List<string> { "Password is not valid"});
            return await Task.FromResult(new GeneralResponse<ReturnLoginDTO> { Success=false , Errors =  E, Message = "Password is not valid" });
        }

        var token = _jwtService.GenerateToken(new Guid(user.Id), user.UserName, user.Email);

        var roles = await _unitOfWork.AppUserRepository.GetuserRoles(Convert.ToString(user.Id));

        
        return await Task.FromResult(new GeneralResponse<ReturnLoginDTO>
        {
            Success = true,
            Message = "Your login is done",
            Data = new ReturnLoginDTO()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = new Guid(user.Id),
                UserName = user.UserName,
                jobTitle = user.jobTitle,
                Token = token,
                Roles = roles.Select(Ra => Ra.Name).ToList()
            }

        });
    }

}
