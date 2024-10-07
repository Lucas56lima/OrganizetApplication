using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace OrganizetApplication.Services
{
    public class SignalRService
    {
        private readonly HubConnection _hubConnection;
        private readonly NavigationManager _navigation;
        public SignalRService()
        {            
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(_navigation.ToAbsoluteUri("/sendnotification"))
                .Build();
        }

        public async Task StartAsync()
        {
            await _hubConnection.StartAsync();
        }

        public async Task StopAsync()
        {
            await _hubConnection.StopAsync();
        }

        public void On<T>(string methodName, Action<T> handler)
        {
            _hubConnection.On(methodName, handler);
        }

        public async Task InvokeAsync(string methodName, params object[] args)
        {
            await _hubConnection.InvokeAsync(methodName, args);
        }
    }

}
