using CBTech.Domain.Common;
using CBTech.Domain.Repositories;

namespace CBTech.Application.UseCases.V1.Fornecedores.ListarFornecedores;

public sealed class ListarFornecedoresHandler(IFornecedorRepository fornecedorRepository) : IListarFornecedoresHandler
{
    public async Task<Result<ResultadoPaginado<FornecedorResponse>>> Handle(ListarFornecedoresRequest request, CancellationToken ct = default)
    {
        var (items, total) = await fornecedorRepository.ListAsync(request.Pagina, request.Tamanho, request.Search, ct);

        if (items == null)
        {
            return new Result<ResultadoPaginado<FornecedorResponse>>();
        }

        var dtos = items.Select(f =>
            new FornecedorResponse(
                f.Id,
                f.NomeFantasia,
                f.RazaoSocial,
                f.Cnpj,
                f.Contato,
                f.Telefone,
                f.Whatsapp,
                f.Email,
                f.Endereco != null ? new EnderecoFornecedorResponse(
                    f.Endereco.Id,
                    f.Endereco.FornecedorId,
                    f.Endereco.Logradouro,
                    f.Endereco.Numero,
                    f.Endereco.Complemento,
                    f.Endereco.Bairro,
                    f.Endereco.Cidade,
                    f.Endereco.Estado,
                    f.Endereco.Cep) : null,
                f.PrazoEntregaDias,
                f.CondicaoPagamento,
                f.Ativo,
                f.CriadoEm)).ToList();

        return Result<ResultadoPaginado<FornecedorResponse>>.Ok(new ResultadoPaginado<FornecedorResponse>(dtos, total, request.Pagina, request.Tamanho));
    }
}
