using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes.IJobInstanceCreators
{
    public interface IJobInstanceCreator
    {
        JobInstance CreateJobInstance(JobType jobType);
    }
}