using YellowPagesUI.Handler;

namespace YellowPagesUI.Extensions
{
    public static class ServiceExtension
    {
        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration Configuration)
        {
            var serviceApiSettings = Configuration.GetSection("ServiceApiSettings").Get<Models.ServiceApiSettings>();
            
            services.AddHttpClient<YellowPagesUI.Services.Interfaces.IClientCredentialTokenService, YellowPagesUI.Services.ClientCredentialTokenService>();
           
            services.AddHttpClient<YellowPagesUI.Services.Interfaces.IIdentityService, YellowPagesUI.Services.IdentityService>();


            services.AddHttpClient<YellowPagesUI.Services.Interfaces.IUserService, YellowPagesUI.Services.UserService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.IdentityBaseUri);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


            services.AddHttpClient<YellowPagesUI.Services.IYellowPagesService, YellowPagesUI.Services.YellowPagesService>(opt =>

            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.YellowPages.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<YellowPagesUI.Services.IEMailInformationService, YellowPagesUI.Services.EMailInformationService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.EMail.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<YellowPagesUI.Services.IPhoneInformationService, YellowPagesUI.Services.PhoneInformationService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Phones.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<YellowPagesUI.Services.ILocationInformationService, YellowPagesUI.Services.LocationInformationService>(opt =>

            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Locations.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();


            services.AddHttpClient<YellowPagesUI.Services.IReportService, YellowPagesUI.Services.ReportService>(opt =>

            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Report.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<YellowPagesUI.Services.Interfaces.IUserService, YellowPagesUI.Services.UserService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.IdentityBaseUri);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        }
    }
}


