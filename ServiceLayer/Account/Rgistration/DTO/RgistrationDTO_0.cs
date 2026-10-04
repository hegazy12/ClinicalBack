
namespace SericeLayer.Account.Rgistration.DTO;

public class RgistrationDTO_0
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string jobTitle { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = new List<string>();
   
}

public class RgistrationDTO
{
    public string Id { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName  { get; set; } = string.Empty;
    public string jobTitle  { get; set; } = string.Empty;
    public string UserName  { get; set; } = string.Empty;
    public string Email     { get; set; } = string.Empty;
}

