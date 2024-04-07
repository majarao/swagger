using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Swagger.Controllers;

/// <summary>
/// Controller that will serve as an example for Swagger documentation
/// </summary>
[ApiController]
[Route("v{version:apiVersion}/[controller]")]
[Produces("text/json")]
[ApiVersion("1.0")]
public class SwaggerController : ControllerBase
{
    /// <summary>
    /// Returns the server's current date and time in UTC format
    /// </summary>
    [HttpGet("now")]
    [ProducesResponseType(typeof(DateTime), StatusCodes.Status200OK)]
    public ActionResult Now() => Ok(DateTime.Now);

    /// <summary>
    /// Returns the StatusCode of the HttpRequest v1
    /// </summary>
    /// <param name="code">StatusCode (length=3)</param>
    /// <remarks>
    /// Example value
    ///
    ///     {
    ///        "code": int,
    ///        "description": "string"
    ///     }
    ///
    /// </remarks>
    [ApiVersion("1.0", Deprecated = true)]
    [HttpGet("status/codes/{code:int:length(3)}")]
    [ProducesResponseType(typeof(Entities.v1.StatusCode), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Entities.v1.StatusCode), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Entities.v1.StatusCode), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Entities.v1.StatusCode), StatusCodes.Status400BadRequest)]
    public ActionResult<Entities.v1.StatusCode> GetStatusCodesv1(int code) =>
        code switch
        {
            200 => Ok(new Entities.v1.StatusCode(code, "Ok")),
            201 => Created("", new Entities.v1.StatusCode(code, "Created")),
            404 => NotFound(new Entities.v1.StatusCode(code, "NotFound")),
            _ => BadRequest(new Entities.v1.StatusCode(code, "Invalid code"))
        };

    /// <summary>
    /// Returns the StatusCode of the HttpRequest v2
    /// </summary>
    /// <param name="code">StatusCode (length=3)</param>
    /// <remarks>
    /// Example value
    ///
    ///     {
    ///        "code": int,
    ///        "description": "string",
    ///        "details" : "string"
    ///     }
    ///
    /// </remarks>
    [ApiVersion("2.0")]
    [HttpGet("status/codes/{code:int:length(3)}")]
    [ProducesResponseType(typeof(Entities.v2.StatusCode), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Entities.v2.StatusCode), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Entities.v2.StatusCode), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Entities.v2.StatusCode), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Entities.v2.StatusCode), StatusCodes.Status400BadRequest)]
    public ActionResult<Entities.v2.StatusCode> GetStatusCodesv2(int code) =>
        code switch
        {
            200 => Ok(new Entities.v2.StatusCode(code, "Ok", "The created Status200OK for the response")),
            201 => Created("", new Entities.v2.StatusCode(code, "Created", "The created Status201Created for the response")),
            401 => Unauthorized(new Entities.v2.StatusCode(code, "Unauthorized", "The created Status401Unauthorized for the response")),
            404 => NotFound(new Entities.v2.StatusCode(code, "NotFound", "The created Status404NotFound for the response")),
            _ => BadRequest(new Entities.v2.StatusCode(code, "Invalid code", "StatusCode does not exist"))
        };
}
