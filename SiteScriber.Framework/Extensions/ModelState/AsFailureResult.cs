using FluentValidation.AspNetCore;
using FluentValidation.Results;
using SiteScriber.Framework.Extensions.ServiceResponses;
using SiteScriber.Framework.Extensions.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SiteScriber.Framework.Contracts;

namespace SiteScriber.Framework.Extensions.ModelState;

public static partial class ModelStateExtensions
{
    public static IActionResult AsFailureResult<TErrorRepresentation>(
        this ServiceResponse<TErrorRepresentation> serviceResponse, ModelStateDictionary modelState)
    {
        if (serviceResponse.Errors is not ValidationResult errors) throw new AggregateException("ServiceResponse.Errors is not ValidationResult");
            
        errors.AddToModelState(modelState, null);
        return new ObjectResult(
            DecorateModelState(modelState, serviceResponse.Status.GetDescription()))
        {
            StatusCode = serviceResponse.Status.ToHttpStatusCode()
        };
    }
}