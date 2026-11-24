using CBTech.Domain.Entities.Produtos;

namespace CBTech.Domain.Repositories;

public interface IProdutoRepository
{
    Task<(IReadOnlyList<Produto> Items, int Total)> ListAsync(
        int page,
        int pageSize,
        string? search,
        Guid? categoriaId,
        Guid? fornecedorId,
        CancellationToken ct = default);
    Task<Produto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<bool> ExistsBySkuAsync(string sku, Guid? excludingId = null, CancellationToken ct = default);
    Task<bool> ExistsByCodigoBarrasAsync(string codigoBarras, Guid? excludingId = null, CancellationToken ct = default);
    Task AddAsync(Produto produto, CancellationToken ct = default);
    Task DeleteAsync(Produto produto, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}