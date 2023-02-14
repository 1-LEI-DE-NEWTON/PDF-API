using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDF_API.Domain.Entities;


namespace PDF_API.Infra.Mappings
{
    public class PdfMap : IEntityTypeConfiguration<PDF>
    {
        public void Configure(EntityTypeBuilder<PDF> builder)
        {
            builder.ToTable("PDF");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();
            
            builder.Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("FileName");

            builder.Property(x => x.FilePath)
                .IsRequired()
                .HasColumnName("FilePath");

            builder.Property(x => x.SetorId)
                .IsRequired()
                .HasColumnName("SetorId");

            builder.Property(x => x.LotacaoId)
                .IsRequired()
                .HasColumnName("LotacaoId");
        }       
    }
}
