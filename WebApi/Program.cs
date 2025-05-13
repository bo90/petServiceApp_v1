using System.Reflection;
using Infrastructure.Data;
using Microsoft.OpenApi.Models;
using WebApi.Extensions;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.Configure<MongoDBSettings>(
            builder.Configuration.GetSection("MongoDbSetiings"));
        
        var services = builder.Services;
        
        services.AddControllers();

        //initial mapper
        services.InstallMapper();
        
        //initial DI
        services.InitilizeControllerConfiguration();
        
        // Add services to the container.
        services.AddAuthorization();
        
        services.AddEndpointsApiExplorer();
        //Swagger
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "BeastService ", Version = "v1" });
            var filePath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
            c.IncludeXmlComments(filePath);
        });

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        
        if (!app.Environment.IsProduction())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NotificationServiceApi V1");
                c.RoutePrefix = "";
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.Run();
    }
}