using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.IWorkUnitCreators;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.Jsons;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.Business.Services;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitCreators.Implementations
{
    public class SequencingWorkUnitCreator : IWorkUnitCreator
    {
        private readonly ISequencingService _sequencingService;
        private static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        public SequencingWorkUnitCreator(ISequencingService sequencingService)
        {
            _sequencingService = sequencingService;
        }

        public async Task<WorkUnit> CreateWorkUnitAsync(long jobInstanceId, Algorithm algorithm = null,
            ProgrammingLanguage programmingLanguage = null)
        {
            var workUnit = new WorkUnit
            {
                JobInstanceId = jobInstanceId,
                Algorithm = algorithm,
                ProgrammingLanguage = programmingLanguage,
                CreationDateTime = DateTime.UtcNow
            };

            var jobInstance = await _sequencingService.GetJobInstanceAsync(jobInstanceId);
            var jobInstanceVertices = jobInstance.GetKeyObject().Vertices;

            await _semaphoreSlim.WaitAsync();

            try
            {
                var usedVerticesAtoms = _sequencingService.GetUsedVertices();
                var notUsedVertices =
                    jobInstanceVertices.Where(v => !usedVerticesAtoms.Contains(v)).ToList();

                if (!notUsedVertices.Any())
                {
                    return null; // do not generate work unit if all vertices used
                }

                var atom = notUsedVertices.First();
                workUnit.DataIn = atom;

                _sequencingService.AddOrUpdateWorkUnit(workUnit);
            }
            finally
            {
                _semaphoreSlim.Release();
            }

            return workUnit;
        }
    }
}