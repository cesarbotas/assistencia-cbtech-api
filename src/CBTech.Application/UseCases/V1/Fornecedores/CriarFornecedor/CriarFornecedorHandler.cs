using CBTech.Domain.Common;
using CBTech.Domain.Repositories;
using CBTech.Domain.Entities.Fornecedores;

namespace CBTech.Application.UseCases.V1.Fornecedores.CriarFornecedor;

public sealed class CriarFornecedorHandler(IFornecedorRepository fornecedorRepository) : ICriarFornecedorHandler
{
    public async Task<Result<CriarFornecedorResponse>> Handle(CriarFornecedorRequest request, CancellationToken ct = default)
    {
        var fornecedor = Fornecedor.Criar(request);

        await fornecedorRepository.AddAsync(fornecedor, ct);

        await fornecedorRepository.SaveChangesAsync(ct);

        return Result<CriarFornecedorResponse>.Ok(new CriarFornecedorResponse(fornecedor.Id));
    }
}
