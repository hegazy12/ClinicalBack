using System.Security.Claims ;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Domain.IUnitOfWork;


namespace ServiceLayer.JWT;
public class JWTModule : IJWTModule
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpireMinutes { get; set; }
    private  IUnitOfWork _unitOfWork;
    
    public JWTModule(string key, string issuer, string audience, int expireMinutes, IUnitOfWork unitOfWork)
    {
        Key = key;
        Issuer = issuer;
        Audience = audience;
        ExpireMinutes = expireMinutes;
        _unitOfWork = unitOfWork;
        
    }
    
    public string GenerateToken(Guid userid,string username, string email)
    {
        
        var roles = _unitOfWork.AppUserRepository.GetuserRoles(userid.ToString()).Result.Select(r => r.Name).ToList();

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, "User"),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, userid.ToString())
        };
        
        foreach(var item in roles)
        {
          claims.Add(new Claim(ClaimTypes.Role, item ?? ""));
        }
        
        var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            issuer: Issuer,
            audience: Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(ExpireMinutes),
            signingCredentials: credentials

        );
        
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }

    
    public ClaimsPrincipal? ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = System.Text.Encoding.UTF8.GetBytes(Key);

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = Issuer,
            
            ValidateAudience = false, 
            ValidAudience = Audience,
            
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            
            ValidateLifetime = true, // Ensures token hasn't expired
            ClockSkew = TimeSpan.FromMinutes(5) // Allowance for server time drift
        };

        try
        {
            SecurityToken validatedToken;
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            return principal;
        }
        catch (SecurityTokenExpiredException)
        {
            // Specific handling for expired tokens
            Console.WriteLine("Token has expired.");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Token validation failed: {ex.Message}");
            return null;
        }
    }
}