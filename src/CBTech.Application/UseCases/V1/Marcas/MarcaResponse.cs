namespace CBTech.Application.UseCases.V1.Marcas;

public record MarcaResponse(
    Guid Id,
    string Nome,
    DateTime CriadoEm,
    DateTime AtualizadoEm
);

