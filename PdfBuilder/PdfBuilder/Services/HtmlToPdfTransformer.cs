using jsreport.AspNetCore;
using jsreport.Types;

namespace PdfBuilder.Services
{
    public class HtmlToPdfTransformer: IHtmlTransformer
    {
        private readonly IJsReportMVCService _jsReportMvcService;

        public HtmlToPdfTransformer(IJsReportMVCService jsReportMvcService)
        {
            _jsReportMvcService = jsReportMvcService;
        }

        public async Task<Stream?> Transform(string html)
        {
            // Render PDF file
            var report = await _jsReportMvcService.RenderAsync(new RenderRequest()
            {
                Template = new Template
                {
                    Content = html,
                    Engine = Engine.None,
                    Recipe = Recipe.ChromePdf,
                    Chrome = new Chrome
                    {
                        MarginTop = "1cm",
                        MarginLeft = "1cm",
                        MarginBottom = "1cm",
                        MarginRight = "1cm"
                    }
                }
            });

            return report?.Content;
        }
    }
}
