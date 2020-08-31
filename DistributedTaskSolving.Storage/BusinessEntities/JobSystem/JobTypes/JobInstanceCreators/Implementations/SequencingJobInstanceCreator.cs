using System;
using System.Collections.Generic;
using System.Linq;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.Jsons;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes.IJobInstanceCreators;
using Newtonsoft.Json.Linq;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes.JobInstanceCreators.Implementations
{
    public class SequencingJobInstanceCreator : IJobInstanceCreator
    {
        private const string chars = "ATGC";

        private string GenerateSequence(int sequenceSize)
        {
            var random = new Random();

            return new string(Enumerable.Repeat(chars, sequenceSize)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        private List<string> SplitSequence(string sequence, byte atomSize)
        {
            var sequenceLength = sequence.Length;
            var atomCount = sequenceLength - atomSize + 1;
            var result = new List<string>(atomCount);

            for (int i = 0; i < atomCount; i++)
            {
                result.Add(sequence.Substring(i, atomSize));
            }

            var resultDistinct = result.Distinct().ToList();

            return resultDistinct;
        }

        public JobInstance CreateJobInstance(JobType jobType)
        {
            var length = 1000;
            var oligonucleotydes = SplitSequence(GenerateSequence(length), 10);

            var instance = new SequencingJobInstanceJson
            {
                Vertices = oligonucleotydes,
                TargetLength = length
            };

            var json = JObject.FromObject(instance);

            var jobInstance = new JobInstance
            {
                Key = json.ToString(),
                JobType = jobType
            };

            return jobInstance;
        }
    }
}