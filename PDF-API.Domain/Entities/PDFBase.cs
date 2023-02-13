
namespace PDF_API.Domain.Entities
{
    public abstract class PDFBase
    {
        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;
        public abstract bool Validate();
    }
}