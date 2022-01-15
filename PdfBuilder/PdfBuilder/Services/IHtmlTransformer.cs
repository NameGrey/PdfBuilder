namespace PdfBuilder.Services
{
    public interface IHtmlTransformer
    {
        public Task<Stream?> Transform(string html);
    }
}
