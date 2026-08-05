using SericeLayer.Account.Login.DTO;
using Domain.Response;
namespace SericeLayer.Account.Login;

public interface ILogin
{
    public Task<GeneralResponse<ReturnLoginDTO>> LoginAsync(LoginDTO loginDto);

}
