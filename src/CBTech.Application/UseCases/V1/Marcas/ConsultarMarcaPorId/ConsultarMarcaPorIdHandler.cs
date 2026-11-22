using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Marcas.ConsultarMarcaPorId;

public class ConsultarMarcaPorIdHandler(IMarcaRepository marcaRepository) : IConsultarMarcaPorIdHandler
{
    public async Task<Result<MarcaResponse>> Handle(Guid id,
        CancellationToken ct = default)
    {
        var marca = await marcaRepository.GetByIdAsync(id, ct);

        if (marca == null)
        {
            return Result<MarcaResponse>.Fail("Marca não encontrado.", 404);
        }

        var marcaDto =
            new MarcaResponse(
                marca.Id,
                marca.Nome,
                marca.CriadoEm,
                marca.AtualizadoEm);

        return Result<MarcaResponse>.Ok(marcaDto);
    }
}
