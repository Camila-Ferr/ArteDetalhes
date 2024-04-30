using ArteDetalhes.Models;
using ArteDetalhes.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArteDetalhes.Controllers;

[Route(("api/[controller]"))]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly InterfaceProdutoRepository _produtoRepositorio;
    private readonly ILogger<ProdutoController> _logger;

    public ProdutoController(InterfaceProdutoRepository produtoRepositorio,ILogger<ProdutoController> logger)
    {
        _produtoRepositorio = produtoRepositorio;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosProdutos()
    {
        _logger.LogInformation("Buscando todos os produtos");
        List<ProdutoModel> produtos = await _produtoRepositorio.BuscarTodosProdutos();
        return Ok(produtos);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ProdutoModel>> BuscarPorId(int id)
    {
        _logger.LogInformation("Buscando produto {id}");
        ProdutoModel produto = await _produtoRepositorio.BuscarPorId(id);
        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult<ProdutoModel>> Cadastrar([FromBody] ProdutoModel produtoModel)
    {
        ProdutoModel produto = await _produtoRepositorio.Adicionar(produtoModel);
        _logger.LogInformation("Produto cadastrado, id : {produto.id}");
        return Ok(produto);
        
    }
    
    [HttpPost("update/{id}")]
    public async Task<ActionResult<ProdutoModel>> Update([FromBody] ProdutoModel produtoModel, int id)
    {
        ProdutoModel produto = await _produtoRepositorio.Atualizar(produtoModel,id);
        return Ok(produto);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<ProdutoModel>> Delete(int id)
    {
        Boolean apagado = await _produtoRepositorio.Apagar(id);
        return Ok(apagado);
    }
    
}