using CBTech.Domain.Entities.Produtos;
using CBTech.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CBTech.Infrastructure.Data.Repositories.Produtos;

public class ProdutoRepository(AppDbContext db) : IProdutoRepository
{
    public async Task<(IReadOnlyList<Produto> Items, int Total)> ListAsync(
        int page,
        int pageSize,
        string? search,
        Guid? categoriaId,
        Guid? fornecedorId,
        CancellationToken ct = default)
    {
        var query = db.Produtos.AsNoTracking().AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(produto => produto.Nome.Contains(search) ||
                produto.Sku.Contains(search) ||
                (produto.CodigoBarras != null && produto.CodigoBarras.Contains(search)));

        if (categoriaId.HasValue)
            query = query.Where(produto => produto.CategoriaId == categoriaId.Value);

        if (fornecedorId.HasValue)
            query = query.Where(produto => produto.FornecedorId == fornecedorId.Value);

        var total = await query.CountAsync(ct);
        var items = await query.OrderBy(produto => produto.Nome)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);

        return (items, total);
    }

    public Task<Produto?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        db.Produtos.FirstOrDefaultAsync(produto => produto.Id == id, ct);

    public Task<bool> ExistsBySkuAsync(string sku, Guid? excludingId = null, CancellationToken ct = default)
    {
        var query = db.Produtos.AsNoTracking().Where(produto => produto.Sku == sku);
        if (excludingId.HasValue)
            query = query.Where(produto => produto.Id != excludingId.Value);

        return query.AnyAsync(ct);
    }

    public Task<bool> ExistsByCodigoBarrasAsync(string codigoBarras, Guid? excludingId = null, CancellationToken ct = default)
    {
        var query = db.Produtos.AsNoTracking().Where(produto => produto.CodigoBarras == codigoBarras);
        if (excludingId.HasValue)
            query = query.Where(produto => produto.Id != excludingId.Value);

        return query.AnyAsync(ct);
    }

    public async Task AddAsync(Produto produto, CancellationToken ct = default) =>
        await db.Produtos.AddAsync(produto, ct);

    public Task DeleteAsync(Produto produto, CancellationToken ct = default)
    {
        db.Produtos.Remove(produto);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync(CancellationToken ct = default) => db.SaveChangesAsync(ct);
}