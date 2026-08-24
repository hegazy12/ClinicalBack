using Microsoft.AspNetCore.SignalR;

namespace ClinicalBackend2;

public class QueryStringUserIdProvider : IUserIdProvider
{
    public string? GetUserId(HubConnectionContext connection)
    {
        return connection.GetHttpContext()?.Request.Query["userId"];
    }
}

public class chat : Hub
{
    public async Task SendToUser(string targetUserId, string message)
    {
        await Clients.User(targetUserId).SendAsync("ReceiveMessage", Context.UserIdentifier, new messages(){massage = message} );
    }

    public async Task SendToConnection(string targetConnectionId, string message)
    {
        await Clients.Client(targetConnectionId).SendAsync("ReceiveMessage", Context.ConnectionId, message);
    }
    
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }
}
public class messages
{
  public DateTime time = DateTime.Now;
  public string massage {get; set;}
  public messages()
    {
    time = DateTime.Now; 
    }
}