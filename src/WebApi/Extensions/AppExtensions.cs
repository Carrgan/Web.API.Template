namespace Template.Web.Api.Extensions;

public static class AppExtensions
{
    public static void UseSwaggerExtension(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(o =>
        {
            o.RoutePrefix = string.Empty;
            o.SwaggerEndpoint("/swagger/v1/swagger.json", "Carrgan - Web Api Template V1");
        });
    }
}