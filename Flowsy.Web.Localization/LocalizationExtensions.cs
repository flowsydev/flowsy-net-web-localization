using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Flowsy.Web.Localization;

public static class LocalizationExtensions
{
    public static CultureInfo? ResolveCulture(this HttpContext httpContext, IOptions<LocalizationOptions> options)
    {
        var acceptedLanguages = httpContext
            .Request
            .Headers
            .AcceptLanguage
            .SelectMany(l => l.Split(","))
            .Select(l => l.ToLower())
            .ToList();

        return options.Value
            .SupportedCultures
            .FirstOrDefault(c =>
                acceptedLanguages.Contains(c.Name.ToLower()) ||
                acceptedLanguages.Contains(c.TwoLetterISOLanguageName.ToLower()));
    }
}