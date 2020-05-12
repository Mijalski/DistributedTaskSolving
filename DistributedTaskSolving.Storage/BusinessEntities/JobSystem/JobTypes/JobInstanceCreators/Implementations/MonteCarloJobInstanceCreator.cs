using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.Jsons;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes.IJobInstanceCreators;
using Newtonsoft.Json.Linq;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes.JobInstanceCreators.Implementations
{
    public class MonteCarloJobInstanceCreator : IJobInstanceCreator
    {
        public JobInstance CreateJobInstance(JobType jobType)
        {
            var json = JObject.FromObject(new MonteCarloJobInstanceJson
            {
                TotalPiCalculationsCount = 10000,
                PiCalculationsCountPerClient = 100,
                CurrentPiValue = 0f
            });

            var jobInstance = new JobInstance
            {
                Key = json.ToString(),
                JobType = jobType
            };

            return jobInstance;
        }
    }
}