using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.Hubs.Clients
{
    public class JobInstanceHubClient : IAsyncDisposable
    {
        public const string HubUrl = "/jobInstancesHub";
        private readonly NavigationManager _navigationManager;
        private HubConnection _hubConnection;
        private bool _started = false;

        public string LastMessageFromServer { get; set; }

        public JobInstanceHubClient(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }


        public async Task StartWorkAsync(string jobTypeName)
        {
            if (!_started)
            {
                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(_navigationManager.ToAbsoluteUri(HubUrl))
                    .Build();

                await _hubConnection.StartAsync();
                _started = true;
                await _hubConnection.SendAsync("StartWorkOnJobType", jobTypeName);
            }
        }

        private void ReceiveWorkUnit(string dataIn)
        {
            Console.WriteLine(dataIn);
        }

        private void ReceiveNoWorkToBeDone()
        {
        }

        private void ReceiveMessage(string message)
        {
            LastMessageFromServer = message;
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}