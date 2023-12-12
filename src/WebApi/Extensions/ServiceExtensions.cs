using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace Template.Web.Api.Extensions;

public static class ServiceExtensions
{
    public static void AddSwaggerExtension(this IServiceCollection services)
    {
        services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Carrgan - Template.Web.Api",
                Description = "A Wen Api template project"
            });
        });
    }

    public static void AddApiVersionExtension(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        });
        services.AddVersionedApiExplorer(o =>
        {
            o.GroupNameFormat = "'v'VVV";
            o.SubstituteApiVersionInUrl = true;
        });
    }
    
    public static void AddCorsExtension(this IServiceCollection services, IConfiguration configuration)
    {
        var cors = configuration["CorsOrigins"]
        .Split(",", StringSplitOptions.RemoveEmptyEntries)
        .Select(o => o)
        .ToArray();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.WithOrigins(cors)
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .WithExposedHeaders("Content-Disposition")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
    }
} 