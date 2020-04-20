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
            builder.HasIndex(_ => _.Name).IsUnique();
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.IpAddress).HasMaxLength(45);
            builder.Property(e => e.Method).HasMaxLength(256);
            builder.Property(e => e.Path).HasMaxLength(2048);
            builder.Property(e => e.Method).HasMaxLength(2048);
            builder.Property(e => e.QueryString).HasMaxLength(2048);
            builder.Property(e => e.RequestBody).HasMaxLength(2048);
        }
    }
}
