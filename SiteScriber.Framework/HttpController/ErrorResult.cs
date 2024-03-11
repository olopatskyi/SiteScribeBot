using FluentValidation.Results;
using SiteScriber.Framework.Extensions.ServiceResponses;
using Microsoft.AspNetCore.Mvc;
using SiteScriber.Framework.Contracts;
using SiteScriber.Framework.Utilities.Api.Response;

namespace SiteScriber.Framework.HttpController;

public abstract partial class HttpController
{
    protected static IActionResult ErrorResult(ServiceResponse<ValidationResult> serviceResponse) 
        => new ObjectResult(new ResponseError(serviceResponse))
        {
            StatusCode = serviceResponse.Status.ToHttpStatusCode()
        };
}