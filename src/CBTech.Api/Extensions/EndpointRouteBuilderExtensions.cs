using CBTech.Api.Endpoints.V1;

namespace CBTech.Api.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapCBTechEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapV1Endpoints();

        // A V2 mapeia apenas os módulos que mudaram (hoje: pagamentos) e reaproveita
        // a V1 no resto. Novos módulos V2 entram em Endpoints/V2/ e em MapV2Endpoints.
        // app.MapV2Endpoints();

        return app;
    }

    /// <summary>
    /// Mapeia os endpoints da versão 2 sob o prefixo <c>/api/v2</c> (apenas módulos alterados).
    /// </summary>
    private static void MapV2Endpoints(this IEndpointRouteBuilder app)
    {
        var v2 = app.MapGroup("/api/v2");
    }

    /// <summary>
    /// Mapeia todos os endpoints da versão 1 sob o prefixo <c>/api/v1</c>.
    /// </summary>
    private static void MapV1Endpoints(this IEndpointRouteBuilder app)
    {
        var v1 = app.MapGroup("/api/v1");

        AuthEndpoints.Map(v1.MapGroup("/auth").WithTags("Auth"));
        RolesEndpoints.Map(v1.MapGroup("/roles").WithTags("Roles"));
        PermissionsEndpoints.Map(v1.MapGroup("/permissions").WithTags("Permissions"));
        UsuariosEndpoints.Map(v1.MapGroup("/usuarios").WithTags("Usuarios"));
    }
}
