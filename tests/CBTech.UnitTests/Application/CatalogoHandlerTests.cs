using CBTech.Application.UseCases.V1.Categorias.ExcluirCategoria;
using CBTech.Application.UseCases.V1.Produtos.CriarProduto;
using CBTech.Domain.Entities.Categorias;
using CBTech.Domain.Entities.Fornecedores;
using CBTech.Domain.Entities.Produtos;
using CBTech.Domain.Repositories;

namespace CBTech.UnitTests.Application;

public class CatalogoHandlerTests
{
    [Fact]
    public async Task CriarProduto_devePersistirQuandoCategoriaEFornecedorExistem()
    {
        var categoriaId = Guid.NewGuid();
        var fornecedorId = Guid.NewGuid();
        var produtoRepository = new ProdutoRepositoryFake();
        var handler = new CriarProdutoHandler(
            produtoRepository,
            new CategoriaRepositoryFake(new Categoria { Id = categoriaId }),
            new FornecedorRepositoryFake(new Fornecedor { Id = fornecedorId }),
            new CriarProdutoValidator());

        var result = await handler.Handle(CriarRequest(categoriaId, fornecedorId));

        Assert.True(result.IsSuccess);
        Assert.NotNull(produtoRepository.AddedProduto);
        Assert.Equal(categoriaId, produtoRepository.AddedProduto.CategoriaId);
        Assert.Equal(fornecedorId, produtoRepository.AddedProduto.FornecedorId);
    }

    [Fact]
    public async Task CriarProduto_deveFalharQuandoCategoriaNaoExiste()
    {
        var produtoRepository = new ProdutoRepositoryFake();
        var handler = new CriarProdutoHandler(
            produtoRepository,
            new CategoriaRepositoryFake(null),
            new FornecedorRepositoryFake(new Fornecedor { Id = Guid.NewGuid() }),
            new CriarProdutoValidator());

        var result = await handler.Handle(CriarRequest(Guid.NewGuid(), Guid.NewGuid()));

        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
        Assert.Null(produtoRepository.AddedProduto);
    }

    [Fact]
    public async Task CriarProduto_deveRejeitarSkuDuplicado()
    {
        var categoriaId = Guid.NewGuid();
        var fornecedorId = Guid.NewGuid();
        var produtoRepository = new ProdutoRepositoryFake();
        produtoRepository.Seed(Produto.Criar(CriarRequest(categoriaId, fornecedorId)));
        var handler = new CriarProdutoHandler(
            produtoRepository,
            new CategoriaRepositoryFake(new Categoria { Id = categoriaId }),
            new FornecedorRepositoryFake(new Fornecedor { Id = fornecedorId }),
            new CriarProdutoValidator());

        var result = await handler.Handle(CriarRequest(categoriaId, fornecedorId));

        Assert.False(result.IsSuccess);
        Assert.Equal(409, result.StatusCode);
        Assert.Null(produtoRepository.AddedProduto);
    }

    [Fact]
    public async Task ExcluirCategoria_deveBloquearCategoriaComProdutosVinculados()
    {
        var categoriaRepository = new CategoriaRepositoryFake(new Categoria { Id = Guid.NewGuid() }, hasProdutos: true);
        var handler = new ExcluirCategoriaHandler(categoriaRepository);

        var result = await handler.Handle(categoriaRepository.Categoria!.Id);

        Assert.False(result.IsSuccess);
        Assert.Equal(409, result.StatusCode);
        Assert.False(categoriaRepository.Deleted);
    }

    private static CriarProdutoRequest CriarRequest(Guid categoriaId, Guid fornecedorId) => new(
        "Tela OLED",
        "TEL-IP13-OLED",
        "7891234567890",
        categoriaId,
        fornecedorId,
        350m,
        650m,
        12,
        3,
        "UN",
        true);

    private sealed class CategoriaRepositoryFake(Categoria? categoria, bool hasProdutos = false) : ICategoriaRepository
    {
        public Categoria? Categoria { get; } = categoria;
        public bool Deleted { get; private set; }

        public Task<(IReadOnlyList<Categoria> Items, int Total)> ListAsync(
            int page, int pageSize, string? search, CancellationToken ct = default) =>
            Task.FromResult<(IReadOnlyList<Categoria> Items, int Total)>((Array.Empty<Categoria>(), 0));

        public Task<Categoria?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
            Task.FromResult(Categoria?.Id == id ? Categoria : null);

        public Task<bool> HasProdutosAsync(Guid id, CancellationToken ct = default) => Task.FromResult(hasProdutos);

        public Task AddAsync(Categoria categoria, CancellationToken ct = default) => Task.CompletedTask;

        public Task DeleteAsync(Categoria categoria, CancellationToken ct = default)
        {
            Deleted = true;
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync(CancellationToken ct = default) => Task.CompletedTask;
    }

    private sealed class FornecedorRepositoryFake(Fornecedor? fornecedor) : IFornecedorRepository
    {
        public Task<(IReadOnlyList<Fornecedor> Items, int Total)> ListAsync(
            int page, int pageSize, string? search, CancellationToken ct = default) =>
            Task.FromResult<(IReadOnlyList<Fornecedor> Items, int Total)>((Array.Empty<Fornecedor>(), 0));

        public Task<Fornecedor?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
            Task.FromResult(fornecedor?.Id == id ? fornecedor : null);

        public Task AddAsync(Fornecedor item, CancellationToken ct = default) => Task.CompletedTask;
        public Task DeleteAsync(Fornecedor item, CancellationToken ct = default) => Task.CompletedTask;
        public Task SaveChangesAsync(CancellationToken ct = default) => Task.CompletedTask;
    }

    private sealed class ProdutoRepositoryFake : IProdutoRepository
    {
        private readonly List<Produto> _produtos = [];

        public Produto? AddedProduto { get; private set; }

        public void Seed(Produto produto) => _produtos.Add(produto);

        public Task<(IReadOnlyList<Produto> Items, int Total)> ListAsync(
            int page,
            int pageSize,
            string? search,
            Guid? categoriaId,
            Guid? fornecedorId,
            CancellationToken ct = default) =>
            Task.FromResult<(IReadOnlyList<Produto> Items, int Total)>((_produtos, _produtos.Count));

        public Task<Produto?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
            Task.FromResult(_produtos.FirstOrDefault(produto => produto.Id == id));

        public Task<bool> ExistsBySkuAsync(string sku, Guid? excludingId = null, CancellationToken ct = default) =>
            Task.FromResult(_produtos.Any(produto => produto.Sku == sku && produto.Id != excludingId));

        public Task<bool> ExistsByCodigoBarrasAsync(string codigoBarras, Guid? excludingId = null, CancellationToken ct = default) =>
            Task.FromResult(_produtos.Any(produto => produto.CodigoBarras == codigoBarras && produto.Id != excludingId));

        public Task AddAsync(Produto produto, CancellationToken ct = default)
        {
            _produtos.Add(produto);
            AddedProduto = produto;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Produto produto, CancellationToken ct = default)
        {
            _produtos.Remove(produto);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync(CancellationToken ct = default) => Task.CompletedTask;
    }
}