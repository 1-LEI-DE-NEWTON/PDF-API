using FluentValidation;
using PDF_API.Domain.Entities;


namespace PDF_API.Domain.Validators
{
    public class PdfValidator : AbstractValidator<PDF>
    {
        public PdfValidator()
        {
            RuleFor(x => x.Pdf)
                .NotNull().WithMessage("O arquivo PDF não pode ser nulo");
            RuleFor(x => x.Pdf)
                .Must(x => x.FileName.EndsWith(".pdf")).WithMessage("O arquivo deve ser do tipo PDF");
        }
    }
}
