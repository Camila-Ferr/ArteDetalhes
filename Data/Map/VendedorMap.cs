using ArteDetalhes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArteDetalhes.Data.Map;

public class VendedorMap : IEntityTypeConfiguration<VendedorModel>
{
    public void Configure(EntityTypeBuilder<VendedorModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Avaliacao).IsRequired();
    }
}