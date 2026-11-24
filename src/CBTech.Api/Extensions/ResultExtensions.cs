using CBTech.Domain.Common;
using Microsoft.AspNetCore.Http;

namespace CBTech.Api.Extensions;

public static class ResultExtensions
{
    public static IResult ToHttpResult<T>(this Result<T> result, int successCode = StatusCodes.Status200OK)
    {
        if (result.ValidationErrors is not null)
            return Results.ValidationProblem(result.ValidationErrors.ToDictionary(k => k.Key, v => v.Value));

        if (!result.IsSuccess)
            return Results.Problem(result.Error, statusCode: result.StatusCode ?? StatusCodes.Status400BadRequest);

        return successCode == StatusCodes.Status201Created
            ? Results.Created(string.Empty, result.Data)
            : Results.Ok(result.Data);
    }
}
