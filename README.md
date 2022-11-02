# Flowsy Web Localization

Localization support for web applications.

## Usage
Add the following lines to your Program.cs file.

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.AddLocalization(options => {
    options.SupportedCultureNames = new[] {"en-US", "es-MX"};
});

// Add other services

var app = builder.Build();

app.UseLocalization();

// Use other services

app.Run();
```
