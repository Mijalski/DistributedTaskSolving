using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistributedTaskSolving.EntityFrameworkCore.Configurations.JobSystem.JobTypes
{
    public class JobTypeConfiguration : IEntityTypeConfiguration<JobType>
    {
        public void Configure(EntityTypeBuilder<JobType> builder)
        {
            builder.ToTable("App.JobSystem.JobType");
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.HasIndex(_ => _.Id);
        }
    }
}