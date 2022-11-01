using System.Globalization;
using System.Text.Json.Serialization;

namespace Flowsy.Web.Localization;

public class LocalizationOptions
{
    public CultureInfo DefaultCulture => SupportedCultures.FirstOrDefault() ?? CultureInfo.CurrentUICulture;
    
    public IEnumerable<CultureInfo> SupportedCultures => SupportedCultureNames.Select(cultureName => new CultureInfo(cultureName)).ToList();

    public IEnumerable<string> SupportedCultureNames { get; set; } = new List<string>();
}