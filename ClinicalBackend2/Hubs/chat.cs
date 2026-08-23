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
    // Called by a client to send a message to one specific user (by connectionId or userIdentifier)
    public async Task SendToUser(string targetUserId, string message)
    {
        await Clients.User(targetUserId).SendAsync("ReceiveMessage", Context.UserIdentifier, message);
    }

    // Alternative: send directly by connection id instead of user identifier
    public async Task SendToConnection(string targetConnectionId, string message)
    {
        await Clients.Client(targetConnectionId).SendAsync("ReceiveMessage", Context.ConnectionId, message);
    }

    public override async Task OnConnectedAsync()
    {
        // Optional: log or track connection
        await base.OnConnectedAsync();
    }
}
