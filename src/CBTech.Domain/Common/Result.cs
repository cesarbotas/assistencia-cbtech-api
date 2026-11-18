namespace CBTech.Domain.Common;

public sealed class Result<T>
{
    public bool IsSuccess { get; private init; }
    public T? Data { get; private init; }
    public string? Error { get; private init; }
    public int? StatusCode { get; private init; }
    public IReadOnlyDictionary<string, string[]>? ValidationErrors { get; private init; }

    public static Result<T> Ok(T data) => new() { IsSuccess = true, Data = data };

    public static Result<T> Fail(string error) => new() { IsSuccess = false, Error = error };

    // Nova sobrecarga aceitando o código (ex: 401, 400, 404)
    public static Result<T> Fail(string error, int statusCode) => new() { IsSuccess = false, Error = error, StatusCode = statusCode };

    public static Result<T> ValidationFail(IReadOnlyDictionary<string, string[]> errors) =>
        new() { IsSuccess = false, ValidationErrors = errors };
}