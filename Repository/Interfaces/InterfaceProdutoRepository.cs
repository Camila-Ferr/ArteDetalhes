using ArteDetalhes.Models;

namespace ArteDetalhes.Repository.Interfaces;

public interface InterfaceProdutoRepository
{
    Task<List<ProdutoModel>> BuscarTodosProdutos();
    Task<ProdutoModel> BuscarPorId(int id);
    Task<ProdutoModel> Adicionar(ProdutoModel produto);
    Task<ProdutoModel> Atualizar(ProdutoModel produto , int id);
    Task<bool> Apagar(int id);

}