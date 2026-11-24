using Microsoft.AspNetCore.Mvc;

namespace CBTech.Api.Endpoints.V1.Categorias;

public class CategoriasRequest
{
    [FromQuery(Name = "pagina")]
    public int? Pagina { get; set; }

    [FromQuery(Name = "tamanho")]
    public int? Tamanho { get; set; }

    [FromQuery(Name = "search")]
    public string? Search { get; set; }
}