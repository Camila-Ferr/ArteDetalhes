namespace ArteDetalhes.Models;
using ArteDetalhes.Enums;
public class VendedorModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public Avaliacao Avaliacao { get; set; }
}