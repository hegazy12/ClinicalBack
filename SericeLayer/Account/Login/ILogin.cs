using SericeLayer.Account.Login.DTO;
namespace SericeLayer.Account.Login;

public interface ILogin
{
    Task<ReturnLoginDTO> LoginAsync(LoginDTO loginDto);

}
