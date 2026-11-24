using CBTech.Domain.Entities.Categorias;

namespace CBTech.Domain.Repositories;

public interface ICategoriaRepository
{
    Task<(IReadOnlyList<Categoria> Items, int Total)> ListAsync(int page, int pageSize, string? search, CancellationToken ct = default);
    Task<Categoria?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<bool> HasProdutosAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Categoria categoria, CancellationToken ct = default);
    Task DeleteAsync(Categoria categoria, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}