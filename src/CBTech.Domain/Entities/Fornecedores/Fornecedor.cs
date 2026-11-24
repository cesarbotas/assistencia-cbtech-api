namespace CBTech.Domain.Entities.Fornecedores;

public class Fornecedor
{
    public Guid Id { get; set; }
    public string RazaoSocial { get; set; } = default!;
    public string NomeFantasia { get; set; } = default!;
    public string? Cnpj { get; set; }
    public string? Contato { get; set; }
    public string? Telefone { get; set; }
    public string? Whatsapp { get; set; }
    public string? Email { get; set; }
    public EnderecoFornecedor? Endereco { get; set; }
    public int PrazoEntregaDias { get; set; }
    public string? CondicaoPagamento { get; set; }
    public bool Ativo { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }

    public static Fornecedor Criar(CriarFornecedorRequest request)
    {
        var fornecedorId = Guid.NewGuid();

        var fornecedor = new Fornecedor
        {
            Id = fornecedorId,
            RazaoSocial = request.RazaoSocial,
            NomeFantasia = request.NomeFantasia,
            Cnpj = request.Cnpj,
            Contato = request.Contato,
            Telefone = request.Telefone,
            Whatsapp = request.Whatsapp,
            Email = request.Email,
            PrazoEntregaDias = request.PrazoEntregaDias,
            CondicaoPagamento = request.CondicaoPagamento,
            Ativo = request.Ativo,
            CriadoEm = DateTime.UtcNow,
            AtualizadoEm = DateTime.UtcNow
        };

        if (request.Endereco != null)
        {
            fornecedor.Endereco = new EnderecoFornecedor
            {
                Id = Guid.NewGuid(),
                FornecedorId = fornecedorId,
                Logradouro = request.Endereco.Logradouro,
                Numero = request.Endereco.Numero,
                Complemento = request.Endereco.Complemento,
                Bairro = request.Endereco.Bairro,
                Cidade = request.Endereco.Cidade,
                Estado = request.Endereco.Estado,
                Cep = request.Endereco.Cep
            };
        }

        return fornecedor;
    }

    public void AtualizarFornecedor(AtualizarFornecedorRequest request)
    {
        RazaoSocial = request.RazaoSocial;
        NomeFantasia = request.NomeFantasia;
        Cnpj = request.Cnpj;
        Contato = request.Contato;
        Telefone = request.Telefone;
        Whatsapp = request.Whatsapp;
        Email = request.Email;
        PrazoEntregaDias = request.PrazoEntregaDias;
        CondicaoPagamento = request.CondicaoPagamento;
        Ativo = request.Ativo;

        if (request.Endereco != null)
        {
            if (Endereco == null)
            {
                Endereco = new EnderecoFornecedor
                {
                    Id = Guid.NewGuid(),
                    FornecedorId = Id,
                    Logradouro = request.Endereco.Logradouro,
                    Numero = request.Endereco.Numero,
                    Complemento = request.Endereco.Complemento,
                    Bairro = request.Endereco.Bairro,
                    Cidade = request.Endereco.Cidade,
                    Estado = request.Endereco.Estado,
                    Cep = request.Endereco.Cep
                };
            }
            else
            {
                Endereco.AtualizarEndereco(request.Endereco);
            }
        }

        AtualizadoEm = DateTime.UtcNow;
    }
}
