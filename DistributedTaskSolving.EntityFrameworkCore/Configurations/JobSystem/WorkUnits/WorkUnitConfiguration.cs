using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistributedTaskSolving.EntityFrameworkCore.Configurations.JobSystem.WorkUnits
{
    public class WorkUnitConfiguration : IEntityTypeConfiguration<WorkUnit>
    {
        public void Configure(EntityTypeBuilder<WorkUnit> builder)
        {
            builder.ToTable("App.JobSystem.WorkUnits");
            builder.HasIndex(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.HasOne(_ => _.JobInstance).WithMany(_ => _.WorkUnits).HasForeignKey(_ => _.JobInstanceId);
            builder.HasOne(_ => _.Algorithm).WithMany().HasForeignKey(_ => _.AlgorithmId);
            builder.HasOne(_ => _.ProgrammingLanguage).WithMany().HasForeignKey(_ => _.ProgrammingLanguageId);
        }
    }
}