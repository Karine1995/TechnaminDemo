using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using TechnaminDemo.Filters;
using TechnaminDemo.Infrastructure;
using TechnaminDemo.Middlewares;

namespace TechnaminDemo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            new ApplicationConfiguration(configuration).BuildApplicationSetting();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMvc(option =>
            {
                option.Filters.Add(new ModelValidationFilter());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechnaminDemo", Version = "v1" });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                OpenApiSecurityRequirement securityRequirement = new();
                OpenApiSecurityScheme key = new();

                key.Reference = new OpenApiReference()
                {
                    Type = new ReferenceType?(ReferenceType.SecurityScheme),
                    Id = "basic"
                };

                securityRequirement.Add(key, System.Array.Empty<string>());

                c.AddSecurityRequirement(securityRequirement);
            });

            BLL.DIConfiguration.ConfigureDI(services, Configuration);

            services.AddMvc().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandleMiddleware>();
            app.UseMiddleware<SetResponseContentType>();

            app.UseSerilogRequestLogging();

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechnaminDemo v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
