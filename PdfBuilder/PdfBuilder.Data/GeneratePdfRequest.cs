using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PdfBuilder.Data
{
    public class GeneratePdfRequest
    {
        [Required] public IFormFile HtmlFile { get; set; }
    }
}