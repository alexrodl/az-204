using Azure.Identity;
using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(
        new Uri("https://ac-204-81327.azconfig.io"),
        new DefaultAzureCredential())
    .ConfigureKeyVault(kv =>
    {
        kv.SetCredential(new DefaultAzureCredential());
    })
    .ConfigureRefresh(refresh =>
    {
        refresh.Register("App:Sentinel", refreshAll: true).SetRefreshInterval(TimeSpan.FromSeconds(30));
    })
    //.Select("App:*", "PreProd")
    .UseFeatureFlags();
});

builder.Services.AddControllersWithViews();

builder.Services.AddAzureAppConfiguration();

builder.Services.AddFeatureManagement();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAzureAppConfiguration();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();