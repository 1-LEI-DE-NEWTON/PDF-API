using System.ComponentModel.DataAnnotations;
using PDF_API.Domain.Validators;

namespace PDF_API.ViewModels
{
    public class PdfViewModel
    {
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        public IFormFile Pdf { get; set; }
        public int SetorId { get; set; }
        public int LotacaoId { get; set; }
        
    }
}
