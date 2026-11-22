using System.Net;
using FluentAssertions;
using CBTech.IntegrationTests.Factory;
using Xunit;

namespace CBTech.IntegrationTests.Api.Paginacao;

/// <summary>
/// Regressão: os GET de listagem usam [AsParameters] com as propriedades de
/// paginação. Se elas forem tipos-valor não-anuláveis (int), o binding do
/// Minimal API as trata como OBRIGATÓRIAS e estoura
/// BadHttpRequestException ("Required parameter 'int Pagina'...") quando o
/// cliente chama o endpoint SEM ?pagina=&amp;tamanho= — foi o que quebrou o
/// Newman no CI. A paginação tem defaults; chamar sem os params deve dar 200.
/// </summary>
[Collection("Integration")]
public class ListagemSemQueryParamsTests
{
    private readonly CustomWebApplicationFactory _factory;

    public ListagemSemQueryParamsTests(CustomWebApplicationFactory factory) => _factory = factory;
}
