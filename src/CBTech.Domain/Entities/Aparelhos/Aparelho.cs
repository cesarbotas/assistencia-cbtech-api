using CBTech.Domain.Entities.Clientes;
using CBTech.Domain.Entities.Marcas;
using CBTech.Domain.Exceptions;

namespace CBTech.Domain.Entities.Aparelhos;

public class Aparelho
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public Guid MarcaId { get; set; }
    public string Modelo { get; set; } = default!;
    public string? Cor { get; set; }
    public string? Imei1 { get; set; }
    public string? Imei2 { get; set; }
    public string? NumeroSerie { get; set; }
    public string? SenhaTela { get; set; }
    public bool Ativo { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }

    // Navegações
    public Cliente Cliente { get; set; } = default!;
    public Marca Marca { get; set; } = default!;

    public static Aparelho Criar(CriarAparelhoRequest request)
    {
        return new Aparelho
        {
            Id = Guid.NewGuid(),
            ClienteId = request.ClienteId,
            MarcaId = request.MarcaId,
            Modelo = request.Modelo,
            Cor = request.Cor,
            Imei1 = request.Imei1,
            Imei2 = request.Imei2,
            NumeroSerie = request.NumeroSerie,
            SenhaTela = request.SenhaTela,
            Ativo = true,
            CriadoEm = DateTime.UtcNow,
            AtualizadoEm = DateTime.UtcNow
        };
    }

    public void ValidarImei()
    {
        if (!string.IsNullOrEmpty(Imei1) && (Imei1.Length < 15 || Imei1.Length > 17))
        {
            throw new DomainException("IMEI 1 deve ter entre 15 e 17 dígitos.");
        }

        if (!string.IsNullOrEmpty(Imei2) && (Imei2.Length < 15 || Imei2.Length > 17))
        {
            throw new DomainException("IMEI 2 deve ter entre 15 e 17 dígitos.");
        }
    }

    public void AtualizarAparelho(AtualizarAparelhoRequest request)
    {
        ClienteId = request.ClienteId;
        MarcaId = request.MarcaId;
        Modelo = request.Modelo;
        Cor = request.Cor;
        Imei1 = request.Imei1;
        Imei2 = request.Imei2;
        NumeroSerie = request.NumeroSerie;
        SenhaTela = request.SenhaTela;
        Ativo = request.Ativo;
        AtualizadoEm = DateTime.UtcNow;

        ValidarImei();
    }
}
