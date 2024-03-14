using FluentValidation.Results;
using SiteScriber.Api.Models.Request;
using SiteScriber.Framework.Contracts;

namespace SiteScriber.Api.Services.Abstractions;

public interface IFileService
{
    Task<ServiceResponse<ValidationResult>> UploadAsync(UploadFileModelRequest request,
        CancellationToken cancellationToken = default);
}