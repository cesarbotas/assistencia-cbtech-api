using CBTech.Application.Common;
using CBTech.Domain.Common;
using CBTech.Domain.Entities.Produtos;
using CBTech.Domain.Repositories;
using FluentValidation;

namespace CBTech.Application.UseCases.V1.Produtos.CriarProduto;

public sealed class CriarProdutoHandler(
    IProdutoRepository produtoRepository,
    ICategoriaRepository categoriaRepository,
    IFornecedorRepository fornecedorRepository,
    IValidator<CriarProdutoRequest> validator) : ICriarProdutoHandler
{
    public async Task<Result<CriarProdutoResponse>> Handle(CriarProdutoRequest request, CancellationToken ct = default)
    {
        var validation = await validator.ValidateAsync(request, ct);
        if (!validation.IsValid)
            return Result<CriarProdutoResponse>.ValidationFail(validation.ToValidationErrors());

        if (await categoriaRepository.GetByIdAsync(request.CategoriaId, ct) is null)
            return Result<CriarProdutoResponse>.Fail("Categoria não encontrada.", 404);

        if (await fornecedorRepository.GetByIdAsync(request.FornecedorId, ct) is null)
            return Result<CriarProdutoResponse>.Fail("Fornecedor não encontrado.", 404);

        if (await produtoRepository.ExistsBySkuAsync(request.Sku, ct: ct))
            return Result<CriarProdutoResponse>.Fail("Já existe um produto com este SKU.", 409);

        if (request.CodigoBarras is not null &&
            await produtoRepository.ExistsByCodigoBarrasAsync(request.CodigoBarras, ct: ct))
            return Result<CriarProdutoResponse>.Fail("Já existe um produto com este código de barras.", 409);

        var produto = Produto.Criar(request);
        await produtoRepository.AddAsync(produto, ct);
        await produtoRepository.SaveChangesAsync(ct);

        return Result<CriarProdutoResponse>.Ok(new CriarProdutoResponse(produto.Id));
    }
}