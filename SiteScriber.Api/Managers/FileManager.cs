using FluentValidation.Results;
using SiteScriber.Api.Managers.Abstractions;
using SiteScriber.Api.Models.Request;
using SiteScriber.Api.Services.Abstractions;
using SiteScriber.Framework;
using SiteScriber.Framework.Contracts;

namespace SiteScriber.Api.Managers;

public class FileManager : LogicalLayerElement, IFileManager
{
    private readonly IFileService _fileService;

    public FileManager(IFileService fileService)
    {
        _fileService = fileService;
    }

    public async Task<ServiceResponse<ValidationResult>> UploadAsync(UploadFileModelRequest request,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await new UploadFileModelRequestValidator().ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ValidationFailure(validationResult);
        }
        
        
        
        var result = await _fileService.UploadAsync(request, cancellationToken);
        return result;
    }
}