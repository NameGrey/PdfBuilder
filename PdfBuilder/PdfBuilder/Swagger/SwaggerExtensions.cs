using Microsoft.OpenApi.Models;

namespace PdfBuilder.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services, string version, string title, string xmlDocName)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new OpenApiInfo { Title = title, Version = version });

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{xmlDocName}.xml"));
            });

            return services;
        }

        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder appBuilder, string version, string title)
        {
            appBuilder.UseSwagger();

            appBuilder.UseSwaggerUI(c =>
            {
                c.EnableValidator();
                c.EnableDeepLinking();
                c.DisplayRequestDuration();
                c.DisplayOperationId();
                c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{title}");
            });

            return appBuilder;
        }
    }
}
