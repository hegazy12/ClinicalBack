using Domain.Models;
using Domain.IRepository;
using SericeLayer.Account.Rgistration.DTO;


namespace SericeLayer.Account.Rgistration;

public class Rgistration : IRgistration
{

    private readonly IApplicationUserRepository _applicationUserRepository;

    public Rgistration(IApplicationUserRepository applicationUserRepository)
    {
        _applicationUserRepository = applicationUserRepository;
    }
    public async Task<ApplicationUser> RegisterAsync(RgistrationDTO_0 DTO)
    {
        // Check if the username or email already exists
        var existingUserByUsername = await _applicationUserRepository.GetByUsernameAsync(DTO.UserName);
        var existingUserByEmail = await _applicationUserRepository.GetByEmailAsync(DTO.Email);

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
        
        var createdUser = await _applicationUserRepository.CreateAsync(user, DTO.Password);
        return createdUser;
    }

}
