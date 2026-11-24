using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Fornecedores.ConsultarFornecedorPorId;

public class ConsultarFornecedorPorIdHandler(IFornecedorRepository fornecedorRepository) : IConsultarFornecedorPorIdHandler
{
    public async Task<Result<FornecedorResponse>> Handle(Guid id, CancellationToken ct = default)
    {
        var fornecedor = await fornecedorRepository.GetByIdAsync(id, ct);

        if (fornecedor == null)
        {
            return Result<FornecedorResponse>.Fail("Fornecedor não encontrado.", 404);
        }

        var fornecedorDto = new FornecedorResponse(
            fornecedor.Id,
            fornecedor.NomeFantasia,
            fornecedor.RazaoSocial,
            fornecedor.Cnpj,
            fornecedor.Contato,
            fornecedor.Telefone,
            fornecedor.Whatsapp,
            fornecedor.Email,
            fornecedor.Endereco != null ? new EnderecoFornecedorResponse(
                fornecedor.Endereco.Id,
                fornecedor.Endereco.FornecedorId,
                fornecedor.Endereco.Logradouro,
                fornecedor.Endereco.Numero,
                fornecedor.Endereco.Complemento,
                fornecedor.Endereco.Bairro,
                fornecedor.Endereco.Cidade,
                fornecedor.Endereco.Estado,
                fornecedor.Endereco.Cep) : null,
            fornecedor.PrazoEntregaDias,
            fornecedor.CondicaoPagamento,
            fornecedor.Ativo,
            fornecedor.CriadoEm);

        return Result<FornecedorResponse>.Ok(fornecedorDto);
    }
}
