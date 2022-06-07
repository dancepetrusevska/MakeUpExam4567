using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UniversityMakeupExam.Data.Entities;
using UniversityMakeupExam.Data.Interfaces;
using UniversityMakeupExam.Data.Repositories;
using UniversityMakeupExam.Models.Profiles;
using UniversityMakeupExam.Service.Interfaces;
using UniversityMakeupExam.Service.Services;
using UniversityMakeupExam.WebApi.Infrastructure;

namespace UniversityMakeupExam.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.AddSingleton<IConfiguration>(Configuration);

            services
                .AddDbContextPool<MakeUpExam4567Context>((serviceProvider, options) =>
                {
                    options
                    .UseSqlServer(Configuration.GetSection("ConnectionStrings")
                            .GetSection("DefaultConnection").Value,
                            x => x.MigrationsAssembly("UniversityMakeupExam.Data"));
                    options
                        .UseInternalServiceProvider(serviceProvider);
                });


            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CompanyProfile());
                mc.AddProfile(new EmployeeProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UniversityMakeupExam.WebApi", Version = "v1" });
            });

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniversityMakeupExam.WebApi v1"));
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
