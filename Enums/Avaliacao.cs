using System.ComponentModel;

namespace ArteDetalhes.Enums;

public enum Avaliacao
{
    [Description("Péssimo")]
    Pessimo = 1,
    [Description("Ruim")]
    Ruim = 2,
    [Description("Razoável")]
    Razoavel = 3,
    [Description("Bom")]
    Bom = 4,
    [Description("Ótimo")]
    Otimo = 5
    
}