using Microsoft.AspNetCore.SignalR;
namespace CharServer.Hubs;

public class ChatHub : Hub
{
    public async Task Send(string user, string message)
    {
        string id = Context.ConnectionId;
        await Clients.All.SendAsync("Receive",user, message, id);  // Receive-raspoznavatel
    }


    public override async Task OnConnectedAsync()
    {
        string id = Context.ConnectionId;
        await Clients.All.SendAsync("Notify", $"{id} is connected!", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        string id = Context.ConnectionId;
        await Clients.All.SendAsync("Notify", $"{id} is disconnected!", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
    }

}
