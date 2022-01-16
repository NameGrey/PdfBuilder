using Microsoft.AspNetCore.Mvc;
using PdfBuilder.Data;
using PdfBuilder.Services.Services;
using System.Net.Mime;

namespace PdfBuilder.Controllers
{
    public class FileController: Controller
    {
        private readonly IHtmlTransformer _htmlTransformer;

        public FileController(IHtmlTransformer htmlTransformer)
        {
            _htmlTransformer = htmlTransformer;
        }

        [RequestSizeLimit(737280000)]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [HttpPost("api/generate/pdf", Name = "GeneratePdfFile")]
        public async Task<IActionResult> GeneratePdfFile([FromForm] GeneratePdfRequest request)
        {
            var pdfStream = await _htmlTransformer.TransformAsync(request.HtmlFile);

            if (pdfStream == null)
            {
                return BadRequest("There was an exception during transforming your html to PDF. Please investigate code base and fix it!");
            }

            await using var ms = new MemoryStream();
            pdfStream.CopyTo(ms);

            return File(ms.ToArray(), MediaTypeNames.Application.Octet, $"{request.HtmlFile.FileName}.pdf");
        }
    }
}
