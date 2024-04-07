namespace Swagger.Entities.v2;

/// <summary>
/// Class to define an ActionResult type in SwaggerController
/// </summary>
/// <param name="code">Status code</param>
/// <param name="description">Status description</param>
/// <param name="details">Status details</param>
public class StatusCode(int code, string description, string details)
{
    /// <summary>
    /// Status code
    /// </summary>
    public int Code { get; set; } = code;

    /// <summary>
    /// Status description
    /// </summary>
    public string Description { get; set; } = description;

    /// <summary>
    /// Status details
    /// </summary>
    public string Details { get; set; } = details;
}
