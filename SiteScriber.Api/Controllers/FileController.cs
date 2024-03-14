using Microsoft.AspNetCore.Mvc;
using SiteScriber.Api.Managers.Abstractions;
using SiteScriber.Api.Models.Request;
using SiteScriber.Framework.HttpController;

namespace SiteScriber.Api.Controllers;

[ApiController]
[Route("api/v1/files")]
public class FileController : HttpController
{
    private readonly IFileManager _fileManager;

    public FileController(IFileManager fileManager)
    {
        _fileManager = fileManager;
    }

    [HttpPost]
    public async Task<IActionResult> UploadAsync([FromBody] UploadFileModelRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await _fileManager.UploadAsync(request, cancellationToken);
        return ActionResult(result);
    }
}