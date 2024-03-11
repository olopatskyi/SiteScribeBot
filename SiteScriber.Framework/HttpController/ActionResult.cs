using System.Net;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SiteScriber.Framework.Contracts;
using SiteScriber.Framework.Utilities.Api.Response;

namespace SiteScriber.Framework.HttpController;

public abstract partial class HttpController
{
    protected static IActionResult ActionResult<T>(ServiceResponse<T, ValidationResult> serviceResponse, 
        HttpStatusCode successStatusCode = HttpStatusCode.OK)
    {
        if (!serviceResponse.IsSuccess) return ErrorResult(serviceResponse);
        
        if (successStatusCode is HttpStatusCode.NoContent)
            return new StatusCodeResult((int)successStatusCode);
        
        return new ObjectResult(new ResponseData(serviceResponse.Result))
        {
            StatusCode = (int)successStatusCode
        };
    }
    
    protected static IActionResult ActionResult<T>(ServiceResponse<(bool hasNext, List<T> data), ValidationResult> serviceResponse,
        HttpStatusCode successStatusCode = HttpStatusCode.OK)
    {
        if (!serviceResponse.IsSuccess) return ErrorResult(serviceResponse);
        
        if (successStatusCode is HttpStatusCode.NoContent)
            return new StatusCodeResult((int)successStatusCode);
        
        return new ObjectResult(new ResponseData(serviceResponse.Result.data)
        {
            Meta = new Dictionary<string, object>
            {
                { "hasNext", serviceResponse.Result.hasNext },
            }
        })
        {
            StatusCode = (int)successStatusCode
        };
    }

    protected static IActionResult ActionResult(ServiceResponse<ValidationResult> serviceResponse)
    {
        return serviceResponse.IsSuccess
            ? new StatusCodeResult((int) HttpStatusCode.NoContent)
            : ErrorResult(serviceResponse);
    }
}