
using YellowPages.Shared.Models;
using YellowPagesUI.Extensions;

namespace Contact.Controllers
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ClientSettings>(Configuration.GetSection("ClientSettings"));
            services.Configure<ServiceApiSettings>(Configuration.GetSection("ServiceApiSettings"));
            services.AddHttpContextAccessor();
            services.AddAccessTokenManagement();
            //services.AddSingleton<PhotoHelper>();
            services.AddScoped<YellowPages.Shared.Services.ISharedIdentityService, YellowPages.Shared.Services.SharedIdentityService>();



            services.AddScoped<YellowPagesUI.Handler.ResourceOwnerPasswordTokenHandler>();
            services.AddScoped<YellowPagesUI.Handler.ClientCredentialTokenHandler>();

            services.AddHttpClientServices(Configuration);
            services.AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme, opts =>
             {
                 opts.LoginPath = "/Auth/SignIn";
                 opts.ExpireTimeSpan = TimeSpan.FromDays(60);
                 opts.SlidingExpiration = true;
                 opts.Cookie.Name = "contactcookie";
             });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}