using CBTech.Domain.Entities.Marcas;
using CBTech.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CBTech.Infrastructure.Data.Repositories.Marcas;

public class MarcaRepository(AppDbContext db) : IMarcaRepository
{
    public async Task<(IReadOnlyList<Marca> Items, int Total)> ListAsync(int page, int pageSize, string? search, CancellationToken ct = default)
    {
        var q = db.Marcas.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(search)) q = q.Where(c => c.Nome.Contains(search));

        var total = await q.CountAsync(ct);

        var items = await q.OrderBy(c => c.Nome).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct);

        return (items, total);
    }

    public Task<Marca?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        db.Marcas.FirstOrDefaultAsync(c => c.Id == id, ct);

    public async Task AddAsync(Marca marca, CancellationToken ct = default) =>
        await db.Marcas.AddAsync(marca, ct);

    public Task DeleteAsync(Marca marca, CancellationToken ct = default)
    {
        db.Marcas.Remove(marca);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync(CancellationToken ct = default) => db.SaveChangesAsync(ct);
}
