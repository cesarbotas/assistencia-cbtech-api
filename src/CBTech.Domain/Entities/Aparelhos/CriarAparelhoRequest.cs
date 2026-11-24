namespace CBTech.Domain.Entities.Aparelhos;

public record CriarAparelhoRequest(
    Guid ClienteId,
    Guid MarcaId,
    string Modelo,
    string? Cor,
    string? Imei1,
    string? Imei2,
    string? NumeroSerie,
    string? SenhaTela
);
