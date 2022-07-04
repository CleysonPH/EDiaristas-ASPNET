using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EDiaristas.Admin.Common.Extensions;

public static class ValidationExceptionExtensions
{
    public static void AddErrorsToModelState(this ValidationException e, ModelStateDictionary modelState)
    {
        modelState.Clear();
        e.Errors
            .ToList()
            .ForEach(x => modelState.AddModelError(x.PropertyName, x.ErrorMessage));
    }
}