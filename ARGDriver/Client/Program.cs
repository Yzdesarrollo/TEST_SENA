using ARGDriver.Client;
using ARGDriver.Client.Interfaces;
using ARGDriver.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Servicios Rol
builder.Services.AddScoped<IRolServices, RolServices>();

// <<<<<<< yuliana
//Servicios Usuario
builder.Services.AddScoped<IUserServices, UserServices>();
// =======
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
// >>>>>>> master

await builder.Build().RunAsync();
