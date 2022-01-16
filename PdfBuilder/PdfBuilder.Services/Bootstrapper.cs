using Microsoft.Extensions.DependencyInjection;
using PdfBuilder.Services.Services;

namespace PdfBuilder.Services
{
    public static class Bootstrapper
    {
        public static void BootstrapPdfBuilderServices(this IServiceCollection container)
        {
            container.AddScoped<IHtmlTransformer, HtmlToPdfTransformer>();
        }
    }
}