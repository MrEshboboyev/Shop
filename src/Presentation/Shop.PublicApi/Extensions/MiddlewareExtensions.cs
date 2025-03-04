using Microsoft.AspNetCore.Builder;
using Shop.PublicApi.Middleware;

namespace Shop.PublicApi.Extensions;

internal static class MiddlewareExtensions
{
    public static void UseErrorHandling(this IApplicationBuilder builder) =>
        builder.UseMiddleware<ErrorHandlingMiddleware>();
}