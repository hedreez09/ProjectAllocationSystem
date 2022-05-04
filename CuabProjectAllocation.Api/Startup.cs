using CuabProjectAllocation.Core.Interface;
using CuabProjectAllocation.Core.Util;
using CuabProjectAllocation.Infrastructure.DAC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CuabProjectAllocation.Api
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

            services.AddControllers();
            services.AddDbContext<CuabDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CuabProjAllocationDb")));

            DependencyResolver.AddServiceDependencies(services);

            var jwtTokenConfig = Configuration.GetSection("SecuritySettings").Get<JwtTokenConfig>();    
            services.AddSingleton(jwtTokenConfig);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CuabProjectAllocation.Api", Version = "v1" });
            });

            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CuabProjectAllocation.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
