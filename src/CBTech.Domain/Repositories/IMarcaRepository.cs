using CBTech.Domain.Entities.Marcas;

namespace CBTech.Domain.Repositories;

public interface IMarcaRepository
{
    Task<(IReadOnlyList<Marca> Items, int Total)> ListAsync(int page, int pageSize, string? search, CancellationToken ct = default);
    Task<Marca?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Marca cliente, CancellationToken ct = default);
    Task DeleteAsync(Marca cliente, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}
