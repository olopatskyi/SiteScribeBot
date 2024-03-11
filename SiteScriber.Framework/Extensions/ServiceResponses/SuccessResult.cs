using FluentValidation.Results;
using SiteScriber.Framework.Contracts;

namespace SiteScriber.Framework.Extensions.ServiceResponses;

public static partial class ServiceResponseExtensions
{
    public static ServiceResponse<TResult, ValidationResult> SuccessResult<TResult>(TResult result) => 
        new ServiceResponse<TResult, ValidationResult>(result);

    public static ServiceResponse<ValidationResult> SuccessResult() => 
        new ServiceResponse<ValidationResult>{IsSuccess = true};
}