using Microsoft.AspNetCore.SignalR;
namespace CharServer.Hubs;

public class ChatHub : Hub
{
    public async Task SendAsync(string user, string message)
    {
        await Clients.All.SendAsync("SendPublicMessage",user, message);  // SendPublicMessage-raspoznavatel
    }


}
