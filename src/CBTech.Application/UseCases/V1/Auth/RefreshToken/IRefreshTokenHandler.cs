using CBTech.Application.UseCases.V1.Auth.Login;
using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Auth.RefreshToken;

public interface IRefreshTokenHandler
{
    Task<Result<LoginResponse>> Handle(RefreshTokenRequest request, string? ip, CancellationToken ct = default);
}
