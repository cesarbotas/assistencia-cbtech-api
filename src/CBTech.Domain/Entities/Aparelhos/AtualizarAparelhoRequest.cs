namespace CBTech.Domain.Entities.Aparelhos;

public record AtualizarAparelhoRequest(
    Guid ClienteId,
    Guid MarcaId,
    string Modelo,
    string? Cor,
    string? Imei1,
    string? Imei2,
    string? NumeroSerie,
    string? SenhaTela,
    bool Ativo = true
);
