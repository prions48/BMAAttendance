using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MudBlazor.Services;
using BMAAttendance.Components;
using BMAAttendance.Data.Email;
using BMAAttendance.Data.Files;
using BMAAttendance.Data.Users;
using Microsoft.EntityFrameworkCore;
using BMAAttendance.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddAuth0WebAppAuthentication(options => {
      options.Domain = builder.Configuration["Auth0:Domain"];
      options.ClientId = builder.Configuration["Auth0:ClientId"];
    });
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents().AddCircuitOptions(e => e.DetailedErrors = true);

builder.Services.AddMudServices();

builder.Services.AddScoped<IEmailSettings,EmailSettings>();
builder.Services.AddScoped<EmailService>();

builder.Services.AddScoped<IFileSettings,FileSettings>();
builder.Services.AddScoped<FileService>();

builder.Services.AddDbContext<UserContext>(o => o.UseSqlServer(builder.Configuration["ConnectionStrings:SQL"]));
builder.Services.AddScoped<UserService>();

builder.Services.AddDbContext<BMAContext>(o => o.UseSqlServer(builder.Configuration["ConnectionStrings:SQL"]));
builder.Services.AddScoped<BMAService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapGet("/Account/Login", async (HttpContext httpContext, string returnUrl = "/") =>
{
  var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
          .WithRedirectUri(returnUrl)
          .Build();

  await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
});

app.MapGet("/Account/Logout", async (HttpContext httpContext) =>
{
  var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
          .WithRedirectUri("/")
          .Build();

  await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
  await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});


app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
