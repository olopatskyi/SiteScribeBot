using FluentValidation.Results;
using SiteScriber.Api.Models.Request;
using SiteScriber.Framework.Contracts;

namespace SiteScriber.Api.Managers.Abstractions;

public interface IFileManager
{
    Task<ServiceResponse<ValidationResult>> UploadAsync(UploadFileModelRequest request,
        CancellationToken cancellationToken = default);
}