

using IdentityModel.Client;
using YellowPages.Shared.Models;

namespace YellowPagesUI.Services
{


    public class ClientCredentialTokenService : YellowPagesUI.Services.Interfaces.IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly ClientSettings _clientSettings;
        private readonly IdentityModel.AspNetCore.AccessTokenManagement.IClientAccessTokenCache _clientAccessTokenCache;
        private readonly HttpClient _httpClient;

        public ClientCredentialTokenService(Microsoft.Extensions.Options.IOptions<ServiceApiSettings> serviceApiSettings, Microsoft.Extensions.Options.IOptions<ClientSettings> clientSettings, IdentityModel.AspNetCore.AccessTokenManagement.IClientAccessTokenCache clientAccessTokenCache, HttpClient httpClient)
        {
            _serviceApiSettings = serviceApiSettings.Value;
            _clientSettings = clientSettings.Value;
            _clientAccessTokenCache = clientAccessTokenCache;
            _httpClient = httpClient;
        }

        public async Task<string> GetToken()
        {
            var currentToken = await _clientAccessTokenCache.GetAsync("WebClientToken");

            if (currentToken != null)
            {
                return currentToken.AccessToken;
            }

            var disco = await _httpClient.GetDiscoveryDocumentAsync(new IdentityModel.Client.DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityBaseUri,
                Policy = new IdentityModel.Client.DiscoveryPolicy { RequireHttps = false }
            });

            if (disco.IsError)
            {
                throw disco.Exception;
            }

            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.WebClient.ClientId,
                ClientSecret = _clientSettings.WebClient.ClientSecret,
                Address = disco.TokenEndpoint
            };

            var newToken = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);

            if (newToken.IsError)
            {
                throw newToken.Exception;
            }

            await _clientAccessTokenCache.SetAsync("WebClientToken", newToken.AccessToken, newToken.ExpiresIn);

            return newToken.AccessToken;
        }
    }
}