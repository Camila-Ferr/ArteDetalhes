using System;

namespace ArteDetalhes.Exceptions
{
    public class ProdutoNaoEncontrado : Exception
    {
        public ProdutoNaoEncontrado() : base("O produto não foi encontrado.") // Mensagem padrão para a exceção
        {
        }
    }
}