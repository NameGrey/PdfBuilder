using Microsoft.AspNetCore.Mvc;
using PdfBuilder.Data;

namespace PdfBuilder.Controllers
{
    public class FileController: Controller
    {
        [RequestSizeLimit(737280000)]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [HttpPost("api/generate/pdf", Name = "GeneratePdfFile")]
        public async Task<IActionResult> GeneratePdfFile([FromForm] GeneratePdfRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
