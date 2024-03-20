using Microsoft.AspNetCore.Mvc;

namespace Mech.Code.Controllers;

[ApiController, Route("")]
[ApiExplorerSettings(IgnoreApi = true)]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Get() => Redirect("/swagger");
}
