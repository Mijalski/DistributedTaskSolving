using System;
using System.Reflection;
using AutoMapper;
using DistributedTaskSolving.Application;
using DistributedTaskSolving.Application.Business.JobSystem.Algorithms.CommandServices;
using DistributedTaskSolving.Application.Business.JobSystem.JobInstances.CommandServices;
using DistributedTaskSolving.Application.Business.JobSystem.JobTypes.QueryServices;
using DistributedTaskSolving.Application.Generics.Endpoints;
using DistributedTaskSolving.Application.Generics.Cqrs.CommandServices;
using DistributedTaskSolving.Application.Generics.Cqrs.QueryServices;
using DistributedTaskSolving.Application.Generics.GridServices;
using DistributedTaskSolving.Application.IGenerics.Endpoints;
using DistributedTaskSolving.Application.IGenerics.GridServices;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.Algorithms;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobInstances.Dto;
using DistributedTaskSolving.Application.Shared.Business.JobSystem.JobTypes.Dto;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.CommandServices;
using DistributedTaskSolving.Application.Shared.IGenerics.Cqrs.QueryServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DistributedTaskSolving.Areas.Identity;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.Algorithms;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances;
using DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes;
using DistributedTaskSolving.EntityFrameworkCore.DbContexts;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

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

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ApplicationDbContext>(opt =>
                    opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                );

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddAutoMapper(typeof(ApplicationModule).Assembly);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            // Generic injection
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddTransient(typeof(IDeleteCommandService<,,,>), typeof(DeleteCommandService<,,,>));
            services.AddTransient(typeof(ICreateCommandService<,,,>), typeof(CreateCommandService<,,,>));
            services.AddTransient(typeof(IUpdateCommandService<,,,>), typeof(UpdateCommandService<,,,>));
            services.AddTransient(typeof(IQueryService<,,,>), typeof(QueryService<,,,>));

            services.AddTransient(typeof(IQueryEndpoint<,,,>), typeof(QueryEndpoint<,,,>));
            services.AddTransient(typeof(IUpdateEndpoint<,,,>), typeof(UpdateQueryEndpoint<,,,>));
            services.AddTransient(typeof(ICreateEndpoint<,,,>), typeof(CreateUpdateQueryEndpoint<,,,>));
            services.AddTransient(typeof(ICrudGridService<,,,>), typeof(CrudGridService<,,,>));

            services.AddTransient(typeof(IQueryGridService<,,,>), typeof(QueryGridService<,,,>));

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

            // Override generic injection
            services.AddTransient(typeof(IQueryService<JobType, Guid, JobTypeDto, string>), typeof(JobTypeQueryService));

            services.AddTransient(typeof(ICreateCommandService<JobInstance, long, JobInstanceDto, long>), typeof(JobInstanceCreateCommandService));
            services.AddTransient(typeof(IUpdateCommandService<JobInstance, long, JobInstanceDto, long>), typeof(JobInstanceUpdateCommandService));
            services.AddTransient(typeof(IQueryService<JobInstance, long, JobInstanceDto, long>), typeof(JobInstanceQueryService));

            services.AddTransient(typeof(ICreateCommandService<Algorithm, long, AlgorithmDto, string>), typeof(AlgorithmCreateCommandService));
            services.AddTransient(typeof(IUpdateCommandService<Algorithm, long, AlgorithmDto, string>), typeof(AlgorithmUpdateCommandService));
            services.AddTransient(typeof(IQueryService<Algorithm, long, AlgorithmDto, string>), typeof(AlgorithmQueryService));
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
