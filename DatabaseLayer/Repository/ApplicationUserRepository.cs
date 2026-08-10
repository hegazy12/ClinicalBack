
using Domain.IRepository;
using Domain.Models;
using Domain.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer.Repository;

public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
{

    private readonly UserManager<ApplicationUser> _userManager;

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

    public async Task<GeneralResponse<ApplicationUser>> CreateAsync(ApplicationUser user, string password)
    {
        var result = await _userManager.CreateAsync(user,password);

        var response = new GeneralResponse<ApplicationUser>
        {
            Success = result.Succeeded ,
            Data = result.Succeeded ? user : null ,
            Message = result.Succeeded ? "User created successfully" : "Failed to create user" ,
            Errors = result.Succeeded ? null : result.Errors.ToDictionary(e => e.Code, e => new List<string> { e.Description })
        };

        return response;
    }
    
    public async Task<ApplicationUser> UpdateAsync(ApplicationUser user)
    {
        var result = await _userManager.UpdateAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<List<IdentityRole>> GetuserRoles(string id)
    {
        var UseRoles = await _context.UserRoles.Where(u => u.UserId == id).Select(ur => ur.RoleId).ToListAsync();
        var roles = await _context.Roles.Where(r => UseRoles.Contains(r.Id)).ToListAsync();
        return roles;
    }

    public async Task<bool> AddRoleAsync(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        
        if (user == null || role == null)
        {
            return false; 
        }

        var result = await _userManager.AddToRoleAsync(user, role.Name);
        return result.Succeeded;
    }
    
    public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<ApplicationUser> GetUserIdAsync(string userId)
    {
        var x = await _userManager.FindByIdAsync(userId);
        return x;
    }

    public async Task<Doctor> GetDoctorbyUserIdAsync(string userId)
    {
        if (userId != null)
        {
            var x = await _context.Doctors.FindAsync(userId);

            x.ApplicationUser = (x != null)? x.ApplicationUser = await _userManager.FindByIdAsync(userId): new ApplicationUser();
            return x;
        }
        else
        {
            return new Doctor();
        }

   
    }
}
