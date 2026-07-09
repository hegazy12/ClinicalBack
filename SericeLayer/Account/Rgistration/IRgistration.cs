
using Domain.Models;
using SericeLayer.Account.Rgistration.DTO;

namespace SericeLayer.Account.Rgistration;

public interface IRgistration 
{

    public Task<ApplicationUser> RegisterAsync(RgistrationDTO_0 user);

}
