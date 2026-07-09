namespace SericeLayer.Account.Rgistration.DTO;

public class ReturnRgistrationDTO
{
    public string Id { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string jobTitle { get; set; } = null!;
    public string Token { get; set; } = null!;
    public List<string> Roles { get; set; } = new List<string>();
    public string Error { get; set; } = null!;
}
