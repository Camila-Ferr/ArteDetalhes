using ArteDetalhes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArteDetalhes.Data.Map;

public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
{
    public void Configure(EntityTypeBuilder<ProdutoModel> builder)
    {
        builder.ToTable("Produtos");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Photo);
    }
}