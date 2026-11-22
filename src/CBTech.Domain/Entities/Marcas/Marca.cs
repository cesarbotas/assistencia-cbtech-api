namespace CBTech.Domain.Entities.Marcas;

public sealed class Marca
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public DateTime CriadoEm { get; private set; }
    public DateTime AtualizadoEm { get; private set; }

    private Marca() { }

    private Marca(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        CriadoEm = DateTime.UtcNow;
        AtualizadoEm = DateTime.UtcNow;
    }

    public static Marca Criar(string nome)
    {
        return new Marca(nome);
    }

    public void AtualizarMarca(string marca)
    {
        Nome = marca;
        AtualizadoEm = DateTime.UtcNow;
    }
}
