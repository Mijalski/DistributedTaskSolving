using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistributedTaskSolving.EntityFrameworkCore.Configurations.JobSystem.Algorithms
{
    public class AlgorithmConfiguration : IEntityTypeConfiguration<Algorithm>
    {
        public void Configure(EntityTypeBuilder<Algorithm> builder)
        {
            builder.ToTable("App.JobSystem.Algorithms");
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.HasIndex(_ => _.Id);
            builder.HasIndex(_ => _.Name).IsUnique();
            builder.HasOne(_ => _.JobType).WithMany(_ => _.Algorithms).HasForeignKey(_ => _.JobTypeId);
            builder.HasOne(_ => _.ProgrammingLanguage).WithMany().HasForeignKey(_ => _.ProgrammingLanguageId);
        }
    }
}