namespace Swagger.Entities;

/// <summary>
/// Class to define an ActionResult type in SwaggerController
/// </summary>
/// <param name="code">Status code</param>
/// <param name="description">Status description</param>
public class StatusCode(int code, string description)
{
    /// <summary>
    /// Status code
    /// </summary>
    public int Code { get; set; } = code;

    /// <summary>
    /// Status description
    /// </summary>
    public string Description { get; set; } = description;
}
