using Microsoft.AspNetCore.Mvc;
using PDF_API.Domain.Entities;

namespace PDF_API.Controllers
{
    [ApiController]    
   
    public class PDFController : ControllerBase
    {
        [HttpPost]
        [Route("SaveFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UploadPDF([FromForm] PDF pdf, CancellationToken cancellationToken)
        {
            await WriteFile(pdf);

            return Ok();
        }

        private async Task<bool> WriteFile([FromForm] PDF pdf)
        {
            bool isSaveSucess = false;
            
            try
            {
                pdf.FileName = Request.Form.Files.First().FileName;

                var fileType = Path.GetExtension(pdf.FileName);

                var filePathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\Files");

                if (!Directory.Exists(filePathBuilt))
                {
                    Directory.CreateDirectory(filePathBuilt);
                }

                var filePath = Path.Combine(filePathBuilt, pdf.FileName);               

                
                if (fileType.ToLower() == ".pdf")
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await pdf.Pdf.CopyToAsync(stream);
                        isSaveSucess = true;
                    }                    
                }
                
                else
                {
                    isSaveSucess = false;
                }
                
            }
            catch (Exception e)
            {
                return false;
            }

            return isSaveSucess;
        }



    }
}
