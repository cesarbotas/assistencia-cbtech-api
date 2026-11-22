using CBTech.Domain.Common;
using CBTech.Domain.Repositories;
using CBTech.Domain.Services.Interfaces;
using CBTech.Domain.Entities.Marcas;
using CBTech.Domain.Entities.Enderecos;

namespace CBTech.Application.UseCases.V1.Marcas.CriarMarca;

public sealed class CriarMarcaHandler(IMarcaRepository marcaRepository) : ICriarMarcaHandler
{
    public async Task<Result<CriarMarcaResponse>> Handle(CriarMarcaRequest request, CancellationToken ct = default)
    {
        var marca = Marca.Criar(request.Nome);

        await marcaRepository.AddAsync(marca, ct);

        await marcaRepository.SaveChangesAsync(ct);

        return Result<CriarMarcaResponse>.Ok(new CriarMarcaResponse(marca.Id));
    }
}
