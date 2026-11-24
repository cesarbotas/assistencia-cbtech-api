namespace CBTech.Application.UseCases.V1.Aparelhos;

public record AparelhoResponse(
    Guid Id,
    Guid ClienteId,
    string NomeCliente,
    Guid MarcaId,
    string NomeMarca,
    string Modelo,
    string? Cor,
    string? Imei1,
    string? Imei2,
    string? NumeroSerie,
    string? SenhaTela,
    bool Ativo,
    DateTime CriadoEm
);
