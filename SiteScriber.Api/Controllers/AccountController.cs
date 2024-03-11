using Microsoft.AspNetCore.Mvc;
using SiteScriber.Framework.HttpController;

namespace SiteScriber.Api.Controllers;

[Route("api/v1/account")]
public class AccountController : HttpController
{
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp()
    {
        return Ok();
    }
}