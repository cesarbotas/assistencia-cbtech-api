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

    public void AtualizarCliente(AtualizarClienteRequest request)
    {
        Nome = request.Nome;
        Email = request.Email;
        Telefone = request.Telefone;

        Endereco.AtualizarEndereco(request.Endereco);

        AtualizadoEm = DateTime.Now;
    }
}
