using Asp.Versioning;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Version = "v1",
        Title = "Swagger documentation example v1",
        Contact = new()
        {
            Name = "Thiago Majarão Longo",
            Email = "majarao@outlook.com",
            Url = new("https://www.linkedin.com/in/majarao/")
        }
    });

    options.SwaggerDoc("v2", new()
    {
        Version = "v2",
        Title = "Swagger documentation example v2",
        Contact = new()
        {
            Name = "Thiago Majarão Longo",
            Email = "majarao@outlook.com",
            Url = new("https://www.linkedin.com/in/majarao/")
        }
    });

    string xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
})
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'V";
        options.SubstituteApiVersionInUrl = true;
    });

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger documentation example v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "Swagger documentation example v2");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
