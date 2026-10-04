
using Domain.Response;
using SericeLayer.Account.Rgistration.DTO;

namespace SericeLayer.Account.Rgistration;

public interface IRgistration 
{

    public Task<GeneralResponse<ReturnRgistrationDTO>> RegisterAsync(RgistrationDTO_0 user);
    public Task<GeneralResponse<IEnumerable<RgistrationDTO>>> GetList();
    public Task<GeneralResponse<IEnumerable<RoleDTO>>> GetRoles();

}
