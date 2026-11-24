using CBTech.Domain.Entities.Categorias;
using CBTech.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CBTech.Infrastructure.Data.Repositories.Categorias;

public class CategoriaRepository(AppDbContext db) : ICategoriaRepository
{
    public async Task<(IReadOnlyList<Categoria> Items, int Total)> ListAsync(
        int page,
        int pageSize,
        string? search,
        CancellationToken ct = default)
    {
        var query = db.Categorias.AsNoTracking().AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(categoria => categoria.Nome.Contains(search) ||
                (categoria.Descricao != null && categoria.Descricao.Contains(search)));

        var total = await query.CountAsync(ct);
        var items = await query.OrderBy(categoria => categoria.Nome)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);

        return (items, total);
    }

    public Task<Categoria?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        db.Categorias.FirstOrDefaultAsync(categoria => categoria.Id == id, ct);

    public Task<bool> HasProdutosAsync(Guid id, CancellationToken ct = default) =>
        db.Produtos.AnyAsync(produto => produto.CategoriaId == id, ct);

    public async Task AddAsync(Categoria categoria, CancellationToken ct = default) =>
        await db.Categorias.AddAsync(categoria, ct);

    public Task DeleteAsync(Categoria categoria, CancellationToken ct = default)
    {
        db.Categorias.Remove(categoria);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync(CancellationToken ct = default) => db.SaveChangesAsync(ct);
}