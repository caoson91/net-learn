using Microsoft.AspNetCore.SignalR;

namespace API
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(string user, string message, string messageId)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, messageId);
        }
    }
}
