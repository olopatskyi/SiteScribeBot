using FluentValidation.Results;
using SiteScriber.Api.Models.Request;
using SiteScriber.Api.Services.Abstractions;
using SiteScriber.Framework.Contracts;

namespace SiteScriber.Api.Services;

public class FileService : IFileService
{
    public Task<ServiceResponse<ValidationResult>> UploadAsync(UploadFileModelRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}