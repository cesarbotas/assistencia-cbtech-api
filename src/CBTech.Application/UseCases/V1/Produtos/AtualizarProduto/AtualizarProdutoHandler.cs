using CBTech.Application.Common;
using CBTech.Domain.Common;
using CBTech.Domain.Entities.Produtos;
using CBTech.Domain.Repositories;
using FluentValidation;

namespace CBTech.Application.UseCases.V1.Produtos.AtualizarProduto;

public sealed class AtualizarProdutoHandler(
    IProdutoRepository produtoRepository,
    ICategoriaRepository categoriaRepository,
    IFornecedorRepository fornecedorRepository,
    IValidator<AtualizarProdutoRequest> validator) : IAtualizarProdutoHandler
{
    public async Task<Result<bool>> Handle(Guid id, AtualizarProdutoRequest request, CancellationToken ct = default)
    {
        var validation = await validator.ValidateAsync(request, ct);
        if (!validation.IsValid)
            return Result<bool>.ValidationFail(validation.ToValidationErrors());

        var produto = await produtoRepository.GetByIdAsync(id, ct);
        if (produto is null)
            return Result<bool>.Fail("Produto não encontrado.", 404);

        if (await categoriaRepository.GetByIdAsync(request.CategoriaId, ct) is null)
            return Result<bool>.Fail("Categoria não encontrada.", 404);

        if (await fornecedorRepository.GetByIdAsync(request.FornecedorId, ct) is null)
            return Result<bool>.Fail("Fornecedor não encontrado.", 404);

        if (await produtoRepository.ExistsBySkuAsync(request.Sku, id, ct))
            return Result<bool>.Fail("Já existe um produto com este SKU.", 409);

        if (request.CodigoBarras is not null &&
            await produtoRepository.ExistsByCodigoBarrasAsync(request.CodigoBarras, id, ct))
            return Result<bool>.Fail("Já existe um produto com este código de barras.", 409);

        produto.AtualizarProduto(request);
        await produtoRepository.SaveChangesAsync(ct);

        return Result<bool>.Ok(true);
    }
}