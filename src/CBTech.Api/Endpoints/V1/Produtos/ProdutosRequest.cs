using Microsoft.AspNetCore.Mvc;

namespace CBTech.Api.Endpoints.V1.Produtos;

public class ProdutosRequest
{
    [FromQuery(Name = "pagina")]
    public int? Pagina { get; set; }

    [FromQuery(Name = "tamanho")]
    public int? Tamanho { get; set; }

    [FromQuery(Name = "search")]
    public string? Search { get; set; }

    [FromQuery(Name = "categoriaId")]
    public Guid? CategoriaId { get; set; }

    [FromQuery(Name = "fornecedorId")]
    public Guid? FornecedorId { get; set; }
}