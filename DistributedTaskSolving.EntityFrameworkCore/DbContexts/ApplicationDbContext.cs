using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using DistributedTaskSolving.Business.BusinessEntities.ApiLogs;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.WorkUnits;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.Business.BusinessEntities.Tenants;
using DistributedTaskSolving.Business.IGenerics;
using DistributedTaskSolving.Business.IGenerics.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.EntityFrameworkCore.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<ApiLog> ApiLogs { get; set; }
        public DbSet<JobInstance> JobInstances { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<WorkUnit> WorkUnits { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Algorithm> Algorithms { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SetGlobalQueryForSoftDelete(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<JobType>().HasData(
                new JobType
                {
                    Name = JobTypesEnums.PasswordBruteForcing,
                    Id = Guid.NewGuid(),
                    Description = "Given a hash of a password, guess the password"
                }
            );

            modelBuilder.Entity<ProgrammingLanguage>().HasData(
                new ProgrammingLanguage
                {
                    Id = 1,
                    CreationDateTime = DateTime.UtcNow,
                    Name = "C#",
                },
                new ProgrammingLanguage
                {
                    Id = 2,
                    CreationDateTime = DateTime.UtcNow,
                    Name = "JavaScript",
                },
                new ProgrammingLanguage
                {
                    Id = 3,
                    CreationDateTime = DateTime.UtcNow,
                    Name = "Rust",
                }
            );
        }

        protected void SetGlobalQueryForSoftDelete(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var isDeletedProperty = entityType.FindProperty("IsDeleted");
                if (isDeletedProperty != null && isDeletedProperty.ClrType == typeof(bool))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "p");
                    var prop = Expression.Property(parameter, isDeletedProperty.PropertyInfo);
                    var filter = Expression.Lambda(Expression.Not(prop), parameter);
                    entityType.SetQueryFilter(filter);
                }
            }
        }

        public override int SaveChanges()
        {
            SetAuditedColumns();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            SetAuditedColumns();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetAuditedColumns()
        {
            var entriesCreated = ChangeTracker
                .Entries()
                .Where(e => e.Entity is ICreationAuditedEntity && e.State == EntityState.Added);

            var entriesModified = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IModificationAuditedEntity && e.State == EntityState.Modified);

            var entriesDeleted = ChangeTracker
                .Entries()
                .Where(e => e.Entity is ISoftDelete && e.State == EntityState.Deleted);

            foreach (var entityEntry in entriesCreated)
            {
                ((ICreationAuditedEntity)entityEntry.Entity).CreationDateTime = DateTime.UtcNow;
            }

            foreach (var entityEntry in entriesModified)
            {
                ((IModificationAuditedEntity)entityEntry.Entity).LastModificationDateTime = DateTime.UtcNow;
            }

            foreach (var entityEntry in entriesDeleted)
            {
                ((ISoftDelete) entityEntry.Entity).IsDeleted = true;
                ((ISoftDelete)entityEntry.Entity).DeletionDateTime = DateTime.UtcNow;
                entityEntry.State = EntityState.Modified;
            }
        }
    }
}