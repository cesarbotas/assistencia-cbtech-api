using CBTech.Domain.Repositories;
using CBTech.Domain.Entities.Aparelhos;
using Microsoft.EntityFrameworkCore;

namespace CBTech.Infrastructure.Data.Repositories.Aparelhos;

public class AparelhoRepository(AppDbContext db) : IAparelhoRepository
{
    public async Task<(IReadOnlyList<Aparelho> Items, int Total)> ListByClienteIdAsync(Guid clienteId, int page, int pageSize, string? search, CancellationToken ct = default)
    {
        var q = db.Aparelhos
            .AsNoTracking()
            .Include(a => a.Cliente)
            .Include(a => a.Marca)
            .Where(a => a.ClienteId == clienteId)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            q = q.Where(a => a.Modelo.Contains(search!) || (a.NumeroSerie != null && a.NumeroSerie.Contains(search!)));
        }

        var total = await q.CountAsync(ct);
        var items = await q.OrderBy(a => a.Modelo).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct);
        return (items, total);
    }

    public async Task<(IReadOnlyList<Aparelho> Items, int Total)> ListAsync(int page, int pageSize, string? search, CancellationToken ct = default)
    {
        var q = db.Aparelhos
            .AsNoTracking()
            .Include(a => a.Cliente)
            .Include(a => a.Marca)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            q = q.Where(a => a.Modelo.Contains(search!) || (a.NumeroSerie != null && a.NumeroSerie.Contains(search!)));
        }

        var total = await q.CountAsync(ct);
        var items = await q.OrderBy(a => a.Modelo).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct);
        return (items, total);
    }

    public async Task<Aparelho?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        await db.Aparelhos
            .Include(a => a.Cliente)
            .Include(a => a.Marca)
            .FirstOrDefaultAsync(a => a.Id == id, ct);

    public async Task AddAsync(Aparelho aparelho, CancellationToken ct = default) =>
        await db.Aparelhos.AddAsync(aparelho, ct);

    public Task DeleteAsync(Aparelho aparelho, CancellationToken ct = default)
    {
        db.Aparelhos.Remove(aparelho);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync(CancellationToken ct = default) => db.SaveChangesAsync(ct);
}
