
using Domain.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DatabaseLayer.Repository;

public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
{

    private readonly UserManager<ApplicationUser> _userManager;

    // Inject UserManager via constructor


    public ApplicationUserRepository(AppDbContext context,UserManager<ApplicationUser> userManager) : base(context)
    {
        _userManager = userManager;
    }

    public async Task<ApplicationUser> GetByUsernameAsync(string username)
    {
        return await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.UserName == username);
    }

    public async Task<ApplicationUser> GetByEmailAsync(string email)
    {
        return await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<ApplicationUser> CreateAsync(ApplicationUser user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        await _context.SaveChangesAsync();
        return user;
    }
    
    public async Task<ApplicationUser> UpdateAsync(ApplicationUser user)
    {
        var result = await _userManager.UpdateAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }


}
