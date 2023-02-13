using Microsoft.EntityFrameworkCore;
using PDF_API.Domain.Entities;
using PDF_API.Infra.Mappings;

namespace PDF_API.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<PDF> PDFs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PdfMap());
        }
    }
}
