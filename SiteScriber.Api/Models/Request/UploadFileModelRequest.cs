using FluentValidation;
using SiteScriber.Framework.FluentValidation;
using SiteScriber.Framework.FluentValidation.Validators;

namespace SiteScriber.Api.Models.Request;

public class UploadFileModelRequest
{
    public string UserId { get; set; }

    public IFormFile File { get; set; }
}

public class UploadFileModelRequestValidator : BasicAbstractValidator<UploadFileModelRequest>
{
    public UploadFileModelRequestValidator()
    {
        RuleFor(x => x.UserId)
            .Required().WithMessage("User id is required");

        RuleFor(x => x.File)
            .Required().WithMessage("A file is required")
            .Must(file => file != null && IsValidFileType(file.FileName))
            .WithMessage("Only .html and .php files are allowed.");
    }

    private static bool IsValidFileType(string fileName)
    {
        var allowedExtensions = new[] { ".html", ".php" };
        var extension = Path.GetExtension(fileName).ToLowerInvariant();
        return allowedExtensions.Contains(extension);
    }
}