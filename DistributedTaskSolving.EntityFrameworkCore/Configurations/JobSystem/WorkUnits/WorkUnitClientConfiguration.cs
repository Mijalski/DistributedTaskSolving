using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistributedTaskSolving.EntityFrameworkCore.Configurations.JobSystem.WorkUnits
{
    public class WorkUnitClientConfiguration : IEntityTypeConfiguration<WorkUnitClient>
    {
        public void Configure(EntityTypeBuilder<WorkUnitClient> builder)
        {
            builder.ToTable("App.JobSystem.WorkUnitClients");
            builder.HasIndex(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
        }
    }
}