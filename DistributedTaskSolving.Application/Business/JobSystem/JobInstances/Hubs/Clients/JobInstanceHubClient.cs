using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.WorkUnits.Dto;
using Microsoft.AspNetCore.Components;

namespace DistributedTaskSolving.Application.Business.JobSystem.JobInstances.Hubs.Clients
{
    public class JobInstanceHubClient : IAsyncDisposable
    {
        public const string HubUrl = "/jobInstancesHub";
        private readonly NavigationManager _navigationManager;
        private HubConnection _hubConnection;
        private bool _started = false;
        
        public JobInstanceHubClient(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }


        public async Task StartWorkAsync(string jobTypeName, WorkUnitClientDto workUnitClientDto, 
            string algorithmName = null, string programmingLanguageName = null)
        {
            if (!_started)
            {
                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(_navigationManager.ToAbsoluteUri(HubUrl))
                    .Build();

                await _hubConnection.StartAsync().ContinueWith(task =>
                {
                    _hubConnection.On<long, string>("ReceiveWorkUnit", ReceiveWorkUnit);
                });

                _started = true;
            }

            await _hubConnection.SendAsync("StartWorkOnJobType", jobTypeName, workUnitClientDto, algorithmName, programmingLanguageName);
        }

        public virtual void ReceiveWorkUnit(long workUnitId, string dataIn)
        {
            Console.WriteLine(dataIn);
        }

        public virtual async Task FinishWorkUnit(long workUnitId, string dataOut, bool isSolved)
        {
            await _hubConnection.SendAsync("FinishWorkUnit", workUnitId, dataOut, isSolved);
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}