using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Flowsy.Web.Localization;

public class RequestCultureMiddleware
{
    private readonly RequestDelegate _next;

    public RequestCultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IOptions<LocalizationOptions> options)
    {
        var acceptedCulture = context.ResolveCulture(options) ?? CultureInfo.CurrentUICulture;
        CultureInfo.CurrentCulture = acceptedCulture;
        CultureInfo.CurrentUICulture = acceptedCulture;
        await _next(context);
    }
}