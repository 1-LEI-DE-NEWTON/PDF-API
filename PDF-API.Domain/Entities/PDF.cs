using Microsoft.AspNetCore.Http;
using PDF_API.Domain.Exceptions;
using PDF_API.Domain.Validators;

namespace PDF_API.Domain.Entities
{
    public class PDF : PDFBase
    {
        //Criando a classe para a API receber os arquivos PDFs
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public IFormFile Pdf { get; set; }
        public int Id { get; set; }
        public int SetorId { get; set; }
        public int LotacaoId { get; set; }
        
        public PDF(string fileName, IFormFile pdf, int id, int setorId, int lotacaoId)
        {
            FileName = fileName;
            Pdf = pdf;
            Id = id;
            SetorId = setorId;
            LotacaoId = lotacaoId;

            Validate();
        }

        public override bool Validate()
        {
            var validator = new PdfValidator();
            var result = validator.Validate(this);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    _errors.Add(error.ErrorMessage);

                    throw new DomainException("Erro ao validar o PDF", _errors);
                }
            }
            
            return true;
        }
    }       
}
