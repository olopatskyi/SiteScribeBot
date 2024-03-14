using FluentValidation.Results;
using SiteScriber.Api.Extensions;
using SiteScriber.Api.Models.Request;
using SiteScriber.Api.Repositories.Abstractions;
using SiteScriber.Api.Services.Abstractions;
using SiteScriber.Data.Entities.Tasks;
using SiteScriber.Data.Repository.Abstractions;
using SiteScriber.Data.Settings;
using SiteScriber.Framework;
using SiteScriber.Framework.Contracts;
using SiteScriber.Framework.Services.QueueService.Storage.Interfaces;

namespace SiteScriber.Api.Services
{
    public class FileService : LogicalLayerElement, IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IUserGptKeyRepository _userGptKeyRepository;
        private readonly IQueueRepository<FileProcessTask> _fileProcessTaskQueueRepository;

        public FileService(
            IFileRepository fileRepository,
            IQueueRepository<FileProcessTask> fileProcessTaskQueueRepository,
            IUserGptKeyRepository userGptKeyRepository)
        {
            _fileRepository = fileRepository;
            _fileProcessTaskQueueRepository = fileProcessTaskQueueRepository;
            _userGptKeyRepository = userGptKeyRepository;
        }

        public async Task<ServiceResponse<ValidationResult>> UploadAsync(UploadFileModelRequest request, CancellationToken cancellationToken = default)
        {
            //Check if user has api key
            var apiKeyResponse = await GetApiKeyAsync(request.UserId, cancellationToken);
            if (!apiKeyResponse.IsSuccess)
            {
                return apiKeyResponse;
            }

            //Upload file to GridFS
            var fileId = await _fileRepository.UploadAsync(new UploadFileSettings
            {
                Name = UserHelper.GetFileName(request.UserId, request.ChatId),
                Stream = await FileHelper.GetStreamFromIFormFileAsync(request.File)
            }, cancellationToken);

            //Create file process task that will be handled by FileProcessor
            await _fileProcessTaskQueueRepository.CreateAsync(new FileProcessTask
            {
                ApiKey = apiKeyResponse.Result,
                ChatId = request.ChatId,
                FileId = fileId,
            }, cancellationToken);

            return Success();
        }

        private async Task<ServiceResponse<string, ValidationResult>> GetApiKeyAsync(string userId, CancellationToken cancellationToken)
        {
            var apiKey = await _userGptKeyRepository.GetOneAsync(userId, cancellationToken);
            if (string.IsNullOrEmpty(apiKey))
            {
                return ValidationFailure<string>(new ValidationResult
                {
                    Errors = [ValidationMessages.UserWithoutApiKey]
                });
            }

            return Success(apiKey);
        }
    }
}