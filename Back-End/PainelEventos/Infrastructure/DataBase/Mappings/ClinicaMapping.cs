using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataBase.Mappings;

public class ClinicaMapping : IEntityTypeConfiguration<Clinica>
{
    public void Configure(EntityTypeBuilder<Clinica> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Nome)
            .HasMaxLength(150)
            .IsRequired();
    }
}
