using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Flowsy.Web.Localization;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddLocalization(this WebApplicationBuilder builder, Action<LocalizationOptions> configure)
    {
        builder.Services.Configure(configure);
        builder.Services.AddLocalization();
        
        return builder;
    }
    
    public static WebApplication UseLocalization(this WebApplication application)
    {
        var localizationOptions = application.Services.GetRequiredService<IOptions<LocalizationOptions>>().Value;
        var supportedCultures = localizationOptions.SupportedCultures.ToList(); 
        
        if (supportedCultures.Count == 0)
            return application;
        
        application
            .UseRequestLocalization(options =>
            {
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                var defaultCulture = localizationOptions.DefaultCulture;
                options.SetDefaultCulture(defaultCulture.Name);
                options.DefaultRequestCulture = new RequestCulture(defaultCulture);
                
                options.ApplyCurrentCultureToResponseHeaders = true;
            })
            .UseMiddleware<RequestCultureMiddleware>();
        
        return application;
    }
}