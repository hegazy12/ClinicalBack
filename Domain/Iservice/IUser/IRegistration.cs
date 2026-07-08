//using Microsoft.AspNetCore.Identity;

namespace Domain.IRepository.IUser;

public interface IRegistration
{
//  public Task<IdentityResult> createNewUser(DTORgistration user);
  public bool verifyUser(string username);
  public bool verifyEmail(string email);
  public bool verifyPhone(string phone);
  public bool verifyPassword(string password);
}
