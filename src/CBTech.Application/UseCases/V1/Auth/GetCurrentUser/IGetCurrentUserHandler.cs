using CBTech.Domain.Common;

namespace CBTech.Application.UseCases.V1.Auth.GetCurrentUser;

public interface IGetCurrentUserHandler
{
    Task<Result<GetCurrentUserResponse>> Handle(Guid userId, CancellationToken ct = default);
}
