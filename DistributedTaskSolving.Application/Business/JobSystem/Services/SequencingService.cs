using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.Business.Services;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.Application.Business.JobSystem.Services
{
    public class SequencingService : ISequencingService
    {
        private readonly IRepository<JobInstance, long> _jobInstanceRepository;

        private static SemaphoreSlim _jobInstanceSemaphore = new SemaphoreSlim(1, 1);

        private static JobInstance _jobInstance;

        private static ConcurrentDictionary<long, WorkUnit> _workUnits;

        public SequencingService(IRepository<JobInstance, long> jobInstanceRepository)
        {
            _jobInstanceRepository = jobInstanceRepository;
        }

        public async Task<JobInstance> GetJobInstanceAsync(long id)
        {
            await _jobInstanceSemaphore.WaitAsync();

            try
            {
                if (_jobInstance == null || _jobInstance.Id != id)
                {
                    _jobInstance = await _jobInstanceRepository.GetAll()
                        .Include(i => i.WorkUnits)
                        .FirstAsync(i => i.Id == id);
                    _workUnits = new ConcurrentDictionary<long, WorkUnit>(_jobInstance.WorkUnits.ToDictionary(u => u.Id, u => u));

                    return _jobInstance;
                }
            }
            finally
            {
                _jobInstanceSemaphore.Release();
            }

            return _jobInstance;
        }

        public void AddOrUpdateWorkUnit(WorkUnit unit)
        {
            _workUnits.AddOrUpdate(unit.Id, unit, (_, wu) => unit);
        }

        public void RemoveWorkUnit(long id)
        {
            _workUnits.Remove(id, out _);
        }

        public IEnumerable<string> GetUsedVertices()
        {
            var staleDate = DateTime.UtcNow - TimeSpan.FromMinutes(5);
            return _workUnits.Values.Where(w => (w.CreationDateTime > staleDate || w.IsSolved) && !w.IsAbandoned).Select(u => u.DataIn);
        }

        public IEnumerable<string> GetSolvedVertices()
        {
            return _workUnits.Values.Where(w => w.IsSolved).Select(u => u.DataIn);
        }
    }
}
