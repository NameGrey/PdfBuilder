using Microsoft.AspNetCore.Http;

namespace PdfBuilder.Services.Services
{
    public interface IHtmlTransformer
    {
        public Task<Stream?> TransformAsync(string html);
        Task<Stream?> TransformAsync(IFormFile html);
    }
}
