using SericeLayer.Account.Login.DTO;
using Domain.IUnitOfWork;
using ServiceLayer.JWT;

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

    public async Task<ReturnLoginDTO> LoginAsync(LoginDTO loginDto)
    {
        var user = await _unitOfWork.AppUserRepository.GetByUsernameAsync(loginDto.UserName);
        if (user == null)
        {
            return await Task.FromResult(new ReturnLoginDTO { Error = "Username is not valid" });
        }

        var passwordValid = await _unitOfWork.AppUserRepository.CheckPasswordAsync(user, loginDto.Password);
        if (!passwordValid)
        {
            return await Task.FromResult(new ReturnLoginDTO { Error = "Invalid password" });
        }
        var token = _jwtService.GenerateToken(Guid.Parse(user.Id), user.UserName, user.Email);

        var roles = await _unitOfWork.AppUserRepository.GetuserRoles(user.Id);
        var M = roles.Select(Ra => Ra.Name).ToList();

        return await Task.FromResult(new ReturnLoginDTO {Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Id = user.Id, UserName = user.UserName, jobTitle = user.jobTitle, Token = token, Roles =  M});
    }

}
