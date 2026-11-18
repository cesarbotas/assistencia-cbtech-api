using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Auth.RegisterUser;

public interface IRegisterUserHandler
{
    Task<Result<RegisterUserResponse>> Handle(RegisterUserRequest request, CancellationToken ct = default);
}
