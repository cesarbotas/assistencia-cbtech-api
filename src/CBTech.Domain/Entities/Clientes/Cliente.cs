using CBTech.Domain.Entities.Enderecos;

namespace CBTech.Domain.Entities.Clientes;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Telefone { get; set; }
    public Endereco Endereco { get; set; } = default!;
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }

    public static Cliente Criar(CriarClienteRequest request)
    {
        var clientId = Guid.NewGuid();

        return new Cliente
        {
            Id = clientId,
            Nome = request.Nome,
            Email = request.Email,
            Telefone = request.Telefone,
            CriadoEm = DateTime.UtcNow,
            AtualizadoEm = DateTime.UtcNow,
            Endereco = new Endereco
            {
                Id = Guid.NewGuid(),
                ClienteId = clientId,
                Logradouro = request.Endereco.Logradouro,
                Numero = request.Endereco.Numero,
                Complemento = request.Endereco.Complemento,
                Bairro = request.Endereco.Bairro,
                Cidade = request.Endereco.Cidade,
                Estado = request.Endereco.Estado,
                Cep = request.Endereco.Cep
            }
        };
    }

    public void AtualizarCliente(AtualizarClienteRequest request)
    {
        Nome = request.Nome;
        Email = request.Email;
        Telefone = request.Telefone;

        Endereco.AtualizarEndereco(request.Endereco);

        AtualizadoEm = DateTime.UtcNow;
    }
}
