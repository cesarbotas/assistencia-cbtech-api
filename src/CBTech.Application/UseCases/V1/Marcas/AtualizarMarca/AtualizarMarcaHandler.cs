using CBTech.Domain.Common;
using CBTech.Domain.Entities.Marcas;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Marcas.AtualizarMarca;

public sealed class AtualizarMarcaHandler(IMarcaRepository marcaRepository) : IAtualizarMarcaHandler
{
    public async Task<Result<bool>> Handle(Guid id, AtualizarMarcaRequest request, CancellationToken ct = default)
    {
        var marca = await marcaRepository.GetByIdAsync(id, ct);

        if (marca is null) return Result<bool>.Fail("Marca não encontrado.");

        marca.AtualizarMarca(request.Nome);

        await marcaRepository.SaveChangesAsync(ct);

        return Result<bool>.Ok(true);
    }
}
