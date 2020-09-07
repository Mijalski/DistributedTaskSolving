using DistributedTaskSolving.Business.BusinessEntities.ApiLogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistributedTaskSolving.EntityFrameworkCore.Configurations.ApiLogs
{
    public class ApiLogConfiguration : IEntityTypeConfiguration<ApiLog>
    {
        public void Configure(EntityTypeBuilder<ApiLog> builder)
        {
            builder.ToTable("App.ApiLogs");
            builder.HasIndex(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Level).HasMaxLength(20);
            builder.Property(e => e.RequestUrl).HasMaxLength(256);
            builder.Property(e => e.ResponseCode).HasMaxLength(10);
        }
    }
}
