using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorUtilities
{
    public class SignalRService3 : IAsyncDisposable
    {
        private readonly HubConnection _hubConnection;

        public event Func<string, string, string, Task>? MessageReceived;

        public SignalRService3()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7232/messagehub")
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<string, string, string>("ReceiveMessage", async (user, message, messageId) =>
            {
                if (MessageReceived != null)
                {
                    await MessageReceived.Invoke(user, message, messageId);
                }
            });

            _hubConnection.StartAsync();
        }

        public async Task SendMessageAsync(string user, string message, string messageId)
        {
            await _hubConnection.SendAsync("SendMessage", user, message, messageId);
        }

        public async Task ConnectAsync()
        {
            if (_hubConnection.State == HubConnectionState.Disconnected)
            {
                await _hubConnection.StartAsync();
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_hubConnection != null && _hubConnection.State != HubConnectionState.Disconnected)
            {
                await _hubConnection.StopAsync(); // Close the connection gracefully
                await _hubConnection.DisposeAsync(); // Dispose the connection
            }
        }
    }
}
