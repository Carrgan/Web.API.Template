using Application;
using Infrastructure.Persistence;
using Infrastructure.Share;
using Template.Web.Api.Extensions;

namespace Template.Web.Api;

public class Startup
{
    public IConfiguration Config { get; }

    public Startup(IConfiguration configuration)
    {
        Config = configuration;
    }

    // Configuration application service
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddPersistenceExtension(Config);
        services.AddInfrastructureShare();
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddRouting(option => option.LowercaseUrls = true);
        
        services.AddMemoryCache();
        
        services.AddSwaggerExtension();
        services.AddApiVersionExtension();
        services.AddCorsExtension(Config);
        
        services.AddApplicationLayer();
        
        services.AddTransient<LocalMockSeedService>();
    }
    
    // Configuration middleware pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        
        app.UseHttpsRedirection();
        app.UseAuthentication();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        
        app.UseSwaggerExtension();

        if (env.IsDevelopment())
        {
            Migration(app);
        }
        
    }

    private void Migration(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var serviceScopeServiceProvider = serviceScope.ServiceProvider;
            var mockService = serviceScopeServiceProvider.GetRequiredService<LocalMockSeedService>();
            mockService.Migration(serviceScopeServiceProvider).GetAwaiter().GetResult();
        }
    }
}