using System;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes.IJobInstanceCreators;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes.JobInstanceCreators.Implementations
{
    public class PasswordBruteForcingJobInstanceCreator : IJobInstanceCreator
    {
        private const string LegalPasswordCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const int PasswordLength = 8;

        public JobInstance CreateJobInstance(JobType jobType)
        {
            var stringChars = new char[PasswordLength];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = LegalPasswordCharacters[random.Next(LegalPasswordCharacters.Length)];
            }

            var jobInstance = new JobInstance
            {
                Key = new string(stringChars),
                JobType = jobType
            };

            return jobInstance;
        }
    }
}