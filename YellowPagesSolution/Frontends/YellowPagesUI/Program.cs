

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;


using YellowPages.Shared.Models;
using YellowPages.Shared.Services;

//using Abstract;
using YellowPagesUI.Business.Abstract;
using YellowPagesUI.Business.Concrete;
using YellowPagesUI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddScoped<IEMailInformationService,
       EMailInformationService>();
builder.Services.AddScoped<IYellowPagesService, YellowPagesService>();
//builder.Services
//    .AddScoped<ILocationInformationService, LocationInformationService>();
//builder.Services
//    .AddScoped<IPhoneInformationService, PhoneInformationService>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();
builder.Services.Configure<ClientSettings>(
    builder.Configuration.GetSection("ClientSettings"));


builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAccessTokenManagement();


builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));

builder.Services.AddScoped<YellowPagesUI.Handler.ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<YellowPagesUI.Handler.ClientCredentialTokenHandler>();

builder.Services.AddHttpClientServices(builder.Configuration);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opts =>
{
    opts.LoginPath = "/Auth/SignIn";
    opts.ExpireTimeSpan = TimeSpan.FromDays(60);
    opts.SlidingExpiration = true;
    opts.Cookie.Name = "contactcookie";
});
//builder.Services.AddSingleton<IYellowPagesReportDal, YellowPagesReportDal>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
