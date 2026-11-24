using CBTech.Domain.Entities.Aparelhos;

namespace CBTech.Domain.Repositories;

public interface IAparelhoRepository
{
    Task<(IReadOnlyList<Aparelho> Items, int Total)> ListByClienteIdAsync(Guid clienteId, int page, int pageSize, string? search, CancellationToken ct = default);
    Task<(IReadOnlyList<Aparelho> Items, int Total)> ListAsync(int page, int pageSize, string? search, CancellationToken ct = default);
    Task<Aparelho?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Aparelho aparelho, CancellationToken ct = default);
    Task DeleteAsync(Aparelho aparelho, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}
