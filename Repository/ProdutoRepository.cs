using ArteDetalhes.Data;
using ArteDetalhes.Exceptions;
using ArteDetalhes.Models;
using ArteDetalhes.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArteDetalhes.Repository;

public class ProdutoRepository : InterfaceProdutoRepository
{
    private readonly SystemDbContext _dbContext;
    public ProdutoRepository(SystemDbContext sistemaDbContext)
    {
        _dbContext = sistemaDbContext;
    }
    public async Task<List<ProdutoModel>> BuscarTodosProdutos()
    {
        return await _dbContext.Produtos.ToListAsync();
    }

    public async Task<ProdutoModel> BuscarPorId(int id)
    {
        return await _dbContext.Produtos.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
    {
        await _dbContext.Produtos.AddAsync(produto);
        await _dbContext.SaveChangesAsync();
        return produto;
    }
    public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
    {
        ProdutoModel produtoId = await BuscarPorId(id);
        if (produtoId == null)
        {
            throw new ProdutoNaoEncontrado();
        }

        produtoId.Nome = produto.Nome;
        produtoId.Descricao = produto.Descricao;
        produtoId.Photo = produto.Photo;
        _dbContext.Produtos.Update(produtoId);
        await _dbContext.SaveChangesAsync();
        return produtoId;
    }
    


    public async Task<bool> Apagar(int id)
    {
        ProdutoModel produtoId = await BuscarPorId(id);
        if (produtoId == null)
        {
            throw new ProdutoNaoEncontrado();
        }

        _dbContext.Produtos.Remove(produtoId);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}