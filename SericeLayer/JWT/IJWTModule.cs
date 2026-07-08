using DatabaseLayer;

namespace ServiceLayer.JWT;

public interface IJWTModule 
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpireMinutes { get; set; }
    public string GenerateToken(Guid guid,string username, string email,AppDbContext dbCon);
}
