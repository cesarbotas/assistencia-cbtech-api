namespace CBTech.Domain.Entities.Categorias;

public class Categoria
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = default!;
    public string? Descricao { get; set; }

    public static Categoria Criar(CriarCategoriaRequest request) => new()
    {
        Id = Guid.NewGuid(),
        Nome = request.Nome,
        Descricao = request.Descricao
    };

    public void AtualizarCategoria(AtualizarCategoriaRequest request)
    {
        Nome = request.Nome;
        Descricao = request.Descricao;
    }
}