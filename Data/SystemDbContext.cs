using ArteDetalhes.Data.Map;
using ArteDetalhes.Models;
using Microsoft.EntityFrameworkCore;
namespace ArteDetalhes.Data;

public class SystemDbContext : DbContext
{
    public SystemDbContext(DbContextOptions<SystemDbContext> options)
        :base(options)
    {

        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=my_db.db");
        // Garantir que o banco de dados seja criado e as migrações sejam aplicadas
        // optionsBuilder.UseSqlite("Data Source=meu_banco_de_dados.db").Migrate();
    }
    
    public DbSet<ProdutoModel> Produtos { get; set; }
    public DbSet<VendedorModel> Vendedores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProdutoMap());
        modelBuilder.ApplyConfiguration(new VendedorMap());
        base.OnModelCreating(modelBuilder);
        this.Database.Migrate();
        
    }
    
}