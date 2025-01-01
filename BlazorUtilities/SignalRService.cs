using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorUtilities
{
    public class SignalRService : IAsyncDisposable
    {
        private bool _isSubscribed = false;
        private HubConnection _hubConnection;

        //public event Action<string, string, string>? MessageReceived;
        public event Action<string, string, string>? MessageReceived;

        public SignalRService()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7232/messagehub")
                .Build();

            _hubConnection.On<string, string, string>("ReceiveMessage", (user, message, messageId) =>
            {
                MessageReceived?.Invoke(user, message, messageId);
            });
        }

        public async Task ConnectAsync()
        {
            if (_hubConnection.State == HubConnectionState.Disconnected)
            {
                await _hubConnection.StartAsync();
            }
        }

        public async Task SendMessageAsync(string user, string message, string messageId)
        {
            await _hubConnection.InvokeAsync("SendMessage", user, message, messageId);
        }

        public async ValueTask DisposeAsync()
        {
            await _hubConnection.DisposeAsync();
        }

        public async Task DisconnectAsync()
        {
            if (_hubConnection.State != HubConnectionState.Disconnected)
            {
                await _hubConnection.StopAsync();
            }
        }
    }
}
