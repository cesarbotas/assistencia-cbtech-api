using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Auth.Login;

public interface ILoginHandler
{
    Task<Result<LoginResponse>> Handle(LoginRequest request, CancellationToken ct = default);
}