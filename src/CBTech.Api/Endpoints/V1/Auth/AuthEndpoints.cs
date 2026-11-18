using System.Security.Claims;
using CBTech.Api.Authorization;
using CBTech.Api.Extensions;
using CBTech.Application.UseCases.V1.Auth.GetCurrentUser;
using CBTech.Application.UseCases.V1.Auth.Login;
using CBTech.Application.UseCases.V1.Auth.Logout;
using CBTech.Application.UseCases.V1.Auth.LogoutAll;
using CBTech.Application.UseCases.V1.Auth.RefreshToken;
using CBTech.Application.UseCases.V1.Auth.RegisterUser;
using Microsoft.AspNetCore.Mvc;

namespace CBTech.Api.Endpoints.V1;

public static class AuthEndpoints
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapPost("/login", async ([FromBody] LoginRequest request, ILoginHandler handler, CancellationToken ct) =>
            (await handler.Handle(request, ct)).ToHttpResult());

        group.MapPost("/register", async ([FromBody] RegisterUserRequest request, IRegisterUserHandler handler, CancellationToken ct) =>
            (await handler.Handle(request, ct)).ToHttpResult(StatusCodes.Status201Created));

        group.MapPost("/refresh", async ([FromBody] RefreshTokenRequest request, IRefreshTokenHandler handler, HttpContext http, CancellationToken ct) =>
        {
            var ip = http.Request.Headers["X-Forwarded-For"].FirstOrDefault()
                ?? http.Connection.RemoteIpAddress?.ToString();
            return (await handler.Handle(request, ip, ct)).ToHttpResult();
        });

        group.MapGet("/me", async (ClaimsPrincipal user, IGetCurrentUserHandler handler, CancellationToken ct) =>
            (await handler.Handle(user.GetUserId(), ct)).ToHttpResult())
            .RequireAuthorization();

        group.MapPost("/logout", async ([FromBody] LogoutRequest request, ClaimsPrincipal user, ILogoutHandler handler, CancellationToken ct) =>
            (await handler.Handle(user.GetUserId(), request, ct)).ToHttpResult())
            .RequireAuthorization();

        group.MapPost("/logout-all", async (ClaimsPrincipal user, ILogoutAllHandler handler, CancellationToken ct) =>
            (await handler.Handle(user.GetUserId(), ct)).ToHttpResult())
            .RequireAuthorization();

        // group.MapPost("/maintenance/purge-tokens", async (IPurgeExpiredRefreshTokensHandler handler, CancellationToken ct) =>
        //     (await handler.Handle(ct)).ToHttpResult())
        //     .RequirePermission("usuarios:gerenciar");
    }
}
