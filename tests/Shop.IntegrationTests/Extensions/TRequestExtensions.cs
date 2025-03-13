using Shop.Core.Extensions;
using System.Net.Mime;
using System.Text;

namespace Shop.IntegrationTests.Extensions;

public static class TRequestExtensions
{
    public static HttpContent ToJsonHttpContent<TRequest>(this TRequest request) =>
        new StringContent(request.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
}