using Microsoft.AspNetCore.Mvc;
using Swagger.Entities;

namespace Swagger.Controllers;

/// <summary>
/// Controller that will serve as an example for Swagger documentation
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("text/json")]
public class SwaggerController : ControllerBase
{
    /// <summary>
    /// Returns the server's current date and time in UTC format
    /// </summary>
    [HttpGet("now")]
    [ProducesResponseType(typeof(DateTime), StatusCodes.Status200OK)]
    public ActionResult Now() => Ok(DateTime.Now);

    /// <summary>
    /// Returns the StatusCode of the HttpRequest
    /// </summary>
    /// <param name="code">StatusCode (length=3)</param>
    [HttpGet("status/codes/{code:int:length(3)}")]
    [ProducesResponseType(typeof(StatusCode), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(StatusCode), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(StatusCode), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(StatusCode), StatusCodes.Status400BadRequest)]
    public ActionResult<StatusCode> GetStatusCodes(int code) =>
        code switch
        {
            200 => Ok(new StatusCode(code, "Ok")),
            201 => Created("", new StatusCode(code, "Created")),
            404 => NotFound(new StatusCode(code, "NotFound")),
            _ => BadRequest(new StatusCode(code, "Código inválido"))
        };
}
