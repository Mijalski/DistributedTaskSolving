using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.IWorkUnitFinishers;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.Jsons;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.Business.Services;
using Microsoft.Extensions.Caching.Memory;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitFinishers.Implementations
{
    public class SequencingWorkUnitFinisher : IWorkUnitFinisher
    {
        private readonly ISequencingService _sequencingService;

        public SequencingWorkUnitFinisher(ISequencingService sequencingService)
        {
            _sequencingService = sequencingService;
        }

        public void FinishJobInstance(JobInstance jobInstance)
        {
            var bestResults = jobInstance.WorkUnits.Where(wu => wu.IsSolved)
                .Select(wu => JsonSerializer.Deserialize<SequencingWorkUnitResult>(wu.DataOut))
                .GroupBy(r => r.UsedVerticesPercentage).OrderByDescending(g => g.Key).First();
            jobInstance.Result = JsonSerializer.Serialize(bestResults.AsEnumerable());
            jobInstance.IsSolved = true;
        }

        public void FinishAbandonedWorkUnit(WorkUnit workUnit)
        {
            _sequencingService.RemoveWorkUnit(workUnit.Id);
        }

        public async Task<bool> FinishWorkUnitAsync(WorkUnit workUnit, string dataOut, bool isSolved)
        {
            workUnit.IsSolved = isSolved;
            workUnit.SubmitDateTime = DateTime.UtcNow;

            var jobInstance = await _sequencingService.GetJobInstanceAsync(workUnit.JobInstanceId);
            var jobInstanceData = jobInstance.GetKeyObject();

            var connections = JsonSerializer.Deserialize<List<Connection>>(dataOut);
            var usedVertices = connections.Select(c => c.To.Atom).Prepend(connections[0].From.Atom);
            var sequence = connections[0].From.Atom + string.Join(null, connections.Select(c => c.To.Atom.Substring(c.Score)));

            var result = new SequencingWorkUnitResult
            {
                Sequence = sequence,
                UsedVerticesPercentage = usedVertices.Distinct().Count() * 100 / jobInstanceData.Vertices.Count(),
                SimilarityPercentage = 0 // TODO: calculate that, maybe use some library
            };

            _sequencingService.AddOrUpdateWorkUnit(workUnit);

            workUnit.DataOut = JsonSerializer.Serialize(result);

            var staleDate = DateTime.Now - TimeSpan.FromMinutes(5);
            var usedVerticesAtoms = _sequencingService.GetSolvedVertices();
            var notUsedVertices =
                jobInstanceData.Vertices.Where(v => !usedVerticesAtoms.Contains(v)).ToList();

            var isJobInstanceSolved = !notUsedVertices.Any();

            return isJobInstanceSolved;
        }

        private class SequencingWorkUnitResult
        {
            public string Sequence { get; set; }

            public int UsedVerticesPercentage { get; set; }

            public int SimilarityPercentage { get; set; }
        }

        private class Connection
        {
            public int Score { get; set; }

            public Vertex From { get; set; }

            public Vertex To { get; set; }
        }

        private class Vertex
        {
            public string Atom { get; set; }
        }
    }
}