using Domain.Models;
using Microsoft.AspNetCore.Identity;
namespace Domain.IRepository;

public interface IApplicationUserRepository : IBaseRepository<ApplicationUser>
{
      
      public Task<ApplicationUser> GetByUsernameAsync(string username);
      public  Task<ApplicationUser> GetByEmailAsync(string email);
      public Task<ApplicationUser> CreateAsync(ApplicationUser user, string password);
      public Task<ApplicationUser> UpdateAsync(ApplicationUser user);
      public Task<List<IdentityRole>> GetuserRoles(string id);
}
