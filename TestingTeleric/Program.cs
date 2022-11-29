using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;
using Telerik.WebReportDesigner.Services;
using TestingTeleric.Controllers;
using TestingTeleric.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddNewtonsoftJson();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<IReportServiceConfiguration>(sp => new ReportServiceConfiguration
{
    ReportingEngineConfiguration = sp.GetService<IConfiguration>(),
    HostAppId = "testingTeleric",
    Storage = new FileStorage(),
    ReportSourceResolver = new UriReportSourceResolver(
        Path.Combine(sp.GetService<IWebHostEnvironment>().WebRootPath, "Reports"))
});

builder.Services.AddSingleton<IReportDesignerServiceConfiguration>(sp => new ReportDesignerServiceConfiguration { 
    DefinitionStorage = new FileDefinitionStorage(Path.Combine(sp.GetService<IWebHostEnvironment>().WebRootPath,"Reports")),
    SettingsStorage = new FileSettingsStorage(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"Telerik Reporting")),
    ResourceStorage = new ResourceStorage(Path.Combine(sp.GetService<IWebHostEnvironment>().WebRootPath,"Resources"))
});

//builder.Services.AddControllers(ReportsController);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
