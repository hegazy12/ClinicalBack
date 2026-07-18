using Microsoft.AspNetCore.SignalR;

namespace ClinicalBackend2;

public class chat : Hub
{
    public void sendMassage (string name,string massage)
    {
        Clients.All.SendAsync("newmassage",name,massage);
    }
}
