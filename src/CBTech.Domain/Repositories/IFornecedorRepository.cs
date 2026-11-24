using CBTech.Domain.Entities.Fornecedores;

namespace CBTech.Domain.Repositories;

public interface IFornecedorRepository
{
    Task<(IReadOnlyList<Fornecedor> Items, int Total)> ListAsync(int page, int pageSize, string? search, CancellationToken ct = default);
    Task<Fornecedor?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Fornecedor fornecedor, CancellationToken ct = default);
    Task DeleteAsync(Fornecedor fornecedor, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}
