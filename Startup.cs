using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using DistributedTaskSolving.Application;
using DistributedTaskSolving.Application.Business.JobSystem.JobInstances.Hubs;
using DistributedTaskSolving.Application.Business.ProgrammingLanguages.QueryGridServices;
using DistributedTaskSolving.Application.Generics.GridServices;
using DistributedTaskSolving.Application.IGenerics.GridServices;
using DistributedTaskSolving.Application.Shared.Business.ProgrammingLanguages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DistributedTaskSolving.Areas.Identity;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.IWorkUnitCreators;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitCreators;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitCreators.Implementations;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitFinishers;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.WorkUnitFinishers.Implementations;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes.JobInstanceCreators;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes.JobInstanceCreators.Implementations;
using DistributedTaskSolving.Business.BusinessEntities.ProgrammingLanguages;
using DistributedTaskSolving.EntityFrameworkCore.DbContexts;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Caching.Memory;
using DistributedTaskSolving.Business.Services;
using DistributedTaskSolving.Application.Business.JobSystem.Services;

namespace DistributedTaskSolving
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssembly(typeof(ApplicationModule).Assembly);
                });

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.AllowAnyMethod().AllowAnyHeader()
                        .WithOrigins("http://localhost:4300")
                        .WithOrigins("http://localhost:8003")
                        .WithOrigins("http://distributed-wasm.szymonchecinski.pl/")
                        .WithOrigins("https://distributed-wasm.szymonchecinski.pl/")
                        .AllowCredentials();
                }));

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ApplicationDbContext>(opt =>
                {
                    opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
                });

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSignalR(o =>
            {
                o.EnableDetailedErrors = true;
                o.MaximumReceiveMessageSize = null;
            });

            services.AddMediatR(typeof(ApplicationModule).Assembly);

            services.AddAutoMapper(typeof(ApplicationModule).Assembly);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            // Generic injection
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddTransient(typeof(ICrudGridService<,,,,,>), typeof(CrudGridService<,,,,,>));
            services.AddTransient(typeof(IQueryGridService<,,>), typeof(QueryGridService<,,>));

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

            // Override generic injection
            services.AddTransient(typeof(IQueryGridService<ProgrammingLanguage, int, ProgrammingLanguageDto>), typeof(ProgrammingLanguageQueryGridService));

            // Work unit creators
            services.AddTransient<PasswordBruteForcingWorkUnitCreator>();
            services.AddTransient<MonteCarloWorkUnitCreator>();
            services.AddTransient<SequencingWorkUnitCreator>();

            services.AddTransient<WorkUnitCreatorServiceResolver>(serviceProvider => key =>
            {
                switch (key)
                {
                    case JobTypeEnums.MonteCarlo:
                        return serviceProvider.GetService<MonteCarloWorkUnitCreator>();
                    case JobTypeEnums.PasswordBruteForcing:
                        return serviceProvider.GetService<PasswordBruteForcingWorkUnitCreator>();
                    case JobTypeEnums.Sequencing:
                        return serviceProvider.GetService<SequencingWorkUnitCreator>();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            // Work unit finisher
            services.AddTransient<PasswordBruteForcingWorkUnitFinisher>();
            services.AddTransient<MonteCarloWorkUnitFinisher>();
            services.AddTransient<SequencingWorkUnitFinisher>();

            services.AddTransient<WorkUnitFinisherServiceResolver>(serviceProvider => key =>
            {
                switch (key)
                {
                    case JobTypeEnums.MonteCarlo:
                        return serviceProvider.GetService<MonteCarloWorkUnitFinisher>();
                    case JobTypeEnums.PasswordBruteForcing:
                        return serviceProvider.GetService<PasswordBruteForcingWorkUnitFinisher>();
                    case JobTypeEnums.Sequencing:
                        return serviceProvider.GetService<SequencingWorkUnitFinisher>();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            // Job instance creators
            services.AddTransient<PasswordBruteForcingJobInstanceCreator>();
            services.AddTransient<MonteCarloJobInstanceCreator>();
            services.AddTransient<SequencingJobInstanceCreator>();

            services.AddTransient<JobInstanceCreatorServiceResolver>(serviceProvider => key =>
            {
                switch (key)
                {
                    case JobTypeEnums.MonteCarlo:
                        return serviceProvider.GetService<MonteCarloJobInstanceCreator>();
                    case JobTypeEnums.PasswordBruteForcing:
                        return serviceProvider.GetService<PasswordBruteForcingJobInstanceCreator>();
                    case JobTypeEnums.Sequencing:
                        return serviceProvider.GetService<SequencingJobInstanceCreator>();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            services.AddTransient<ISequencingService, SequencingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(Configuration["App:SwaggerEndPoint"], "My API v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapHub<JobInstanceHub>("/jobInstancesHub");
            });
        }
    }
}
