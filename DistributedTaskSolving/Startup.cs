using System.Reflection;
using AutoMapper;
using DistributedTaskSolving.Application;
using DistributedTaskSolving.Application.Business.JobSystem.JobInstances.Hubs;
using DistributedTaskSolving.Application.Generics.GridServices;
using DistributedTaskSolving.Application.IGenerics.GridServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DistributedTaskSolving.Areas.Identity;
using DistributedTaskSolving.EntityFrameworkCore.DbContexts;
using DistributedTaskSolving.EntityFrameworkCore.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
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
            services.AddSignalR();

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
            app.UseSignalR(routes =>
            {
                routes.MapHub<JobInstanceHub>("/jobInstancesHub");
            });

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
