using DistributedTaskSolving.Business.Generics.Entities;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits
{
    public class WorkUnitClient : CreationAuditedEntity<long>
    {
        public string UserAgent { get; set; }
        public string RamSize { get; set; }
    }
}