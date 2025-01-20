using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorUtilities
{
    public class SignalRService4
    {
        private readonly HubConnection _hubConnection;

        public event Action<string, string, string> MessageReceived;

        public SignalRService4(string hubUrl)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUrl)
                .Build();

            _hubConnection.On<string, string, string>("ReceiveMessage", (user, message, messageId) =>
            {
                MessageReceived?.Invoke(user, message, messageId);
            });
        }

        public async Task ConnectAsync()
        {
            await _hubConnection.StartAsync();
        }

        public async Task SendMessageAsync(string user, string message, string messageId)
        {
            await _hubConnection.InvokeAsync("SendMessage", user, message, messageId);
        }

        public async Task DisconnectAsync()
        {
            await _hubConnection.StopAsync();
            await _hubConnection.DisposeAsync();
        }
    }
}
