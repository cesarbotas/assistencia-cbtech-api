using FluentValidation.Results;

namespace CBTech.Application.Common;

public static class ValidationResultExtensions
{
    public static IReadOnlyDictionary<string, string[]> ToValidationErrors(this ValidationResult result) =>
        result.Errors
            .GroupBy(error => error.PropertyName)
            .ToDictionary(group => group.Key, group => group.Select(error => error.ErrorMessage).ToArray());
}