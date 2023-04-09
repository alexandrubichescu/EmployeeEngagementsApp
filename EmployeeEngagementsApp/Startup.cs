using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository.Implementations;
using Repository.Interfaces;
using Services.Implementations;
using Services.Interfaces;
using Services.Mappers;

namespace EmployeeEngagementsApp;

public class StartUp
{
    public IConfiguration Configuration { get; }

    public StartUp(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Add Entity Framework Core
        services.AddDbContext<BlueDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BlueDbConnection")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBadgeRepository, BadgeRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddAutoMapper(typeof(MappingProfile));

        // Add Swagger/OpenAPI
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            // Enable Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            });
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        // Run migrations on startup
        //dbContext.Database.Migrate();
    }
}
