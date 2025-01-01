using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorApp
{
    public class SignalRService2
    {
        private HubConnection _hubConnection;

        public event Action<string, string>? MessageReceived;

        public SignalRService2()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7232/messagehub")
                .Build();

            _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                MessageReceived?.Invoke(user, message);
            });
        }

        public async Task ConnectAsync()
        {
            if (_hubConnection.State == HubConnectionState.Disconnected)
            {
                await _hubConnection.StartAsync();
            }
        }

        public async Task SendMessageAsync(string user, string message)
        {
            await _hubConnection.InvokeAsync("SendMessage", user, message);
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
