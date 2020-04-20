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
            builder.Ignore(_ => _.Name);
            builder.HasOne(_ => _.Algorithm).WithMany().HasForeignKey(_ => _.AlgorithmId);
        }
    }
}