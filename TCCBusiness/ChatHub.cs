using Microsoft.AspNetCore.SignalR;
using TCCDomain.Entities;

namespace TCCBusiness
{
    public class ChatHub : Hub, IChatHub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
