using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistributedTaskSolving.EntityFrameworkCore.Configurations.JobSystem.JobInstances
{
    public class JobInstanceConfiguration : IEntityTypeConfiguration<JobInstance>
    {
        public void Configure(EntityTypeBuilder<JobInstance> builder)
        {
            builder.ToTable("App.JobSystem.JobInstances");
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.HasIndex(_ => _.Id);
            builder.HasOne(_ => _.JobType).WithMany(_ => _.JobInstances).HasForeignKey(_ => _.JobTypeId);
        }
    }
}