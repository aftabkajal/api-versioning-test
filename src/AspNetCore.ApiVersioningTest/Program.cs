using Asp.Versioning;
using AspNetCore.ApiVersioningTest.Constants;
using AspNetCore.ApiVersioningTest.SwaggerConfig;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var env = builder.Environment;

// Use null-coalescing operator to handle missing configuration values safely

builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

var configuration = builder.Configuration;

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(ApiVersions.MAJOR, ApiVersions.MINOR);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader());
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = ApiVersionConfiguration.GROUP_NAME_FORMAT; // e.g: v1.0.0
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
                    ApiVersions.VERSION,
                    new OpenApiInfo
                    {
                        Title = ApiVersionConfiguration.VERSION_TITLE,
                        Version = ApiVersions.VERSION,
                    });

    c.SwaggerDoc(
        ApiVersions.MINOR_VERSION,
        new OpenApiInfo
        {
            Title = ApiVersionConfiguration.MINOR_VERSION_TITLE,
            Version = ApiVersions.MINOR_VERSION,
        });

    // Add versioning to the path
    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

        var versions = methodInfo.DeclaringType?
            .GetCustomAttributes(true)
            .OfType<ApiVersionAttribute>()
            .SelectMany(attr => attr.Versions);

        return versions?.Any(v => $"v{v.ToString()}" == docName) ?? false;
    });

    // Add API version parameter in Swagger
    c.OperationFilter<SwaggerVersioningOperationFilter>();

    // Include XML comments for all assemblies dynamically
    var baseDirectory = AppContext.BaseDirectory;
    var xmlFiles = Directory.GetFiles(baseDirectory, "*.xml", SearchOption.TopDirectoryOnly);

    foreach (var xmlFile in xmlFiles)
    {
        c.IncludeXmlComments(Path.Combine(baseDirectory, xmlFile));
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.EnableFilter();
        c.DisplayRequestDuration();
        c.SwaggerEndpoint($"/swagger/{ApiVersions.VERSION}/swagger.json", ApiVersionConfiguration.VERSION_TITLE);
        c.SwaggerEndpoint($"/swagger/{ApiVersions.MINOR_VERSION}/swagger.json", ApiVersionConfiguration.MINOR_VERSION_TITLE);
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.Run();


