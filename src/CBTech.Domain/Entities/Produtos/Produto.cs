using CBTech.Domain.Entities.Categorias;
using CBTech.Domain.Entities.Fornecedores;

namespace CBTech.Domain.Entities.Produtos;

public class Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Sku { get; set; } = default!;
    public string? CodigoBarras { get; set; }
    public Guid CategoriaId { get; set; }
    public Guid FornecedorId { get; set; }
    public decimal PrecoCusto { get; set; }
    public decimal PrecoVenda { get; set; }
    public int EstoqueAtual { get; set; }
    public int EstoqueMinimo { get; set; }
    public string UnidadeMedida { get; set; } = default!;
    public bool Ativo { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }
    public Categoria Categoria { get; set; } = default!;
    public Fornecedor Fornecedor { get; set; } = default!;

    public static Produto Criar(CriarProdutoRequest request)
    {
        var agora = DateTime.UtcNow;

        return new Produto
        {
            Id = Guid.NewGuid(),
            Nome = request.Nome,
            Sku = request.Sku,
            CodigoBarras = request.CodigoBarras,
            CategoriaId = request.CategoriaId,
            FornecedorId = request.FornecedorId,
            PrecoCusto = request.PrecoCusto,
            PrecoVenda = request.PrecoVenda,
            EstoqueAtual = request.EstoqueAtual,
            EstoqueMinimo = request.EstoqueMinimo,
            UnidadeMedida = request.UnidadeMedida,
            Ativo = request.Ativo,
            CriadoEm = agora,
            AtualizadoEm = agora
        };
    }

    public void AtualizarProduto(AtualizarProdutoRequest request)
    {
        Nome = request.Nome;
        Sku = request.Sku;
        CodigoBarras = request.CodigoBarras;
        CategoriaId = request.CategoriaId;
        FornecedorId = request.FornecedorId;
        PrecoCusto = request.PrecoCusto;
        PrecoVenda = request.PrecoVenda;
        EstoqueAtual = request.EstoqueAtual;
        EstoqueMinimo = request.EstoqueMinimo;
        UnidadeMedida = request.UnidadeMedida;
        Ativo = request.Ativo;
        AtualizadoEm = DateTime.UtcNow;
    }
}