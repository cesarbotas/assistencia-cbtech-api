using CBTech.Domain.Repositories;
using CBTech.Domain.Entities.Fornecedores;
using Microsoft.EntityFrameworkCore;

namespace CBTech.Infrastructure.Data.Repositories.Fornecedores;

public class FornecedorRepository(AppDbContext db) : IFornecedorRepository
{
    public async Task<(IReadOnlyList<Fornecedor> Items, int Total)> ListAsync(int page, int pageSize, string? search, CancellationToken ct = default)
    {
        var q = db.Fornecedores.AsNoTracking().Include(f => f.Endereco).AsQueryable();
        if (!string.IsNullOrWhiteSpace(search)) q = q.Where(f => f.NomeFantasia.Contains(search) || f.RazaoSocial.Contains(search) || (f.Cnpj != null && f.Cnpj.Contains(search)));
        var total = await q.CountAsync(ct);
        var items = await q.OrderBy(f => f.NomeFantasia).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct);
        return (items, total);
    }

    public Task<Fornecedor?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        db.Fornecedores.Include(f => f.Endereco).FirstOrDefaultAsync(f => f.Id == id, ct);

    public async Task AddAsync(Fornecedor fornecedor, CancellationToken ct = default) =>
        await db.Fornecedores.AddAsync(fornecedor, ct);

    public Task DeleteAsync(Fornecedor fornecedor, CancellationToken ct = default)
    {
        db.Fornecedores.Remove(fornecedor);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync(CancellationToken ct = default) => db.SaveChangesAsync(ct);
}
