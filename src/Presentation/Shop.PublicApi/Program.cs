using Asp.Versioning;
using CorrelationId;
using CorrelationId.DependencyInjection;
using FluentValidation;
using FluentValidation.Resources;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OwaspHeaders.Core.Extensions;
using Scalar.AspNetCore;
using Shop.Application;
using Shop.Core;
using Shop.Core.Extensions;
using Shop.Infrastructure;
using Shop.PublicApi.Extensions;
using Shop.Query;
using StackExchange.Profiling;
using System.Globalization;
using System.IO.Compression;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services
    .Configure<GzipCompressionProviderOptions>(compressionOptions =>
        compressionOptions.Level = CompressionLevel.Fastest) // Set Gzip compression level
    .Configure<JsonOptions>(jsonOptions => jsonOptions.JsonSerializerOptions.Configure()) // Configure JSON options
    .Configure<RouteOptions>(routeOptions => routeOptions.LowercaseUrls = true) // Use lowercase URLs
    .AddHttpClient() // Add HttpClient services
    .AddHttpContextAccessor() // Add HttpContextAccessor
    .AddResponseCompression(compressionOptions =>
    {
        compressionOptions.EnableForHttps = true; // Enable response compression for HTTPS
        compressionOptions.Providers.Add<GzipCompressionProvider>(); // Add Gzip compression provider
    })
    .AddEndpointsApiExplorer() // Add API explorer for endpoints
    .AddApiVersioning(versioningOptions =>
    {
        versioningOptions.DefaultApiVersion = ApiVersion.Default; // Set default API version
        versioningOptions.ReportApiVersions = true; // Report API versions
        versioningOptions.AssumeDefaultVersionWhenUnspecified = true; // Assume default version when unspecified
    })
    .AddApiExplorer(explorerOptions =>
    {
        explorerOptions.GroupNameFormat = "'v'VVV"; // Set group name format for API versions
        explorerOptions.SubstituteApiVersionInUrl = true; // Substitute API version in URL
    });

builder.Services.AddOpenApi(); // Add OpenAPI/Swagger services
builder.Services.AddDataProtection(); // Add data protection services
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(behaviorOptions =>
    {
        behaviorOptions.SuppressMapClientErrors = true; // Suppress client errors mapping
        behaviorOptions.SuppressModelStateInvalidFilter = true; // Suppress model state invalid filter
    })
    .AddJsonOptions(_ => { }); // Add JSON options

// Adding the application services in ASP.NET Core DI.
builder.Services
    .ConfigureAppSettings() // Configure application settings
    .AddInfrastructure() // Add infrastructure services
    .AddCommandHandlers() // Add command handlers
    .AddQueryHandlers() // Add query handlers
    .AddWriteDbContext(builder.Environment) // Add write database context
    .AddWriteOnlyRepositories() // Add write-only repositories
    .AddReadDbContext() // Add read database context
    .AddReadOnlyRepositories() // Add read-only repositories
    .AddCacheService(builder.Configuration) // Add cache service
    .AddHealthChecks(builder.Configuration) // Add health checks
    .AddDefaultCorrelationId(); // Add default correlation ID

// MiniProfiler for .NET
// https://miniprofiler.com/dotnet/
builder.Services.AddMiniProfiler(options =>
{
    // Route: /profiler/results-index
    options.RouteBasePath = "/profiler"; // Set route base path for MiniProfiler
    options.ColorScheme = ColorScheme.Dark; // Set color scheme to dark
    options.EnableServerTimingHeader = true; // Enable server timing header
    options.TrackConnectionOpenClose = true; // Track connection open/close
    options.EnableDebugMode = builder.Environment.IsDevelopment(); // Enable debug mode in development
}).AddEntityFramework(); // Add Entity Framework support for MiniProfiler

// Validating the services added in the ASP.NET Core DI.
builder.Host.UseDefaultServiceProvider((context, serviceProviderOptions) =>
{
    serviceProviderOptions.ValidateScopes = context.HostingEnvironment.IsDevelopment(); // Validate scopes in development
    serviceProviderOptions.ValidateOnBuild = true; // Validate on build
});

// Using the Kestrel Server (linux).
builder.WebHost.UseKestrel(kestrelOptions => kestrelOptions.AddServerHeader = false); // Use Kestrel server and remove server header

// FluentValidation global configuration.
ValidatorOptions.Global.DisplayNameResolver = (_, member, _) => member?.Name; // Set display name resolver
ValidatorOptions.Global.LanguageManager = new LanguageManager { Enabled = true, Culture = new CultureInfo("en-US") }; // Set language manager

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Use developer exception page in development
}

app.UseHealthChecks("/health", new HealthCheckOptions
{
    Predicate = _ => true, // Run all health checks
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse // Write health check UI response
});

app.MapOpenApi(); // Map OpenAPI/Swagger endpoints

// Route: /scalar/v1
app.MapScalarApiReference(scalarOptions =>
{
    scalarOptions.DarkMode = true; // Enable dark mode
    scalarOptions.DotNetFlag = false; // Disable .NET flag
    scalarOptions.HideDownloadButton = true; // Hide download button
    scalarOptions.HideModels = true; // Hide models
    scalarOptions.Title = "Shop API"; // Set API title
});

app.UseErrorHandling(); // Use custom error handling middleware
app.UseResponseCompression(); // Use response compression
app.UseHttpsRedirection(); // Use HTTPS redirection
app.UseSecureHeadersMiddleware(); // Use secure headers middleware
app.UseMiniProfiler(); // Use MiniProfiler
app.UseCorrelationId(); // Use correlation ID middleware
app.UseAuthentication(); // Use authentication
app.UseAuthorization(); // Use authorization
app.MapControllers(); // Map controller routes

await app.RunAppAsync(); // Run the application
