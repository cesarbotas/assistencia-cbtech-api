using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Marcas.ExcluirMarca;

public sealed class ExcluirMarcaHandler(IMarcaRepository marcaRepository) : IExcluirMarcaHandler
{
    public async Task<Result<bool>> Handle(Guid id, CancellationToken ct = default)
    {
        var marca = await marcaRepository.GetByIdAsync(id, ct);

        if (marca is null) return Result<bool>.Fail("Marca não encontrado.");

        await marcaRepository.DeleteAsync(marca, ct);

        await marcaRepository.SaveChangesAsync(ct);

        return Result<bool>.Ok(true);
    }
}
