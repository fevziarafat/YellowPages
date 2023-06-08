namespace YellowPagesUI.Handler
{
    public class ClientCredentialTokenHandler : DelegatingHandler
    {
        private readonly YellowPagesUI.Services.Interfaces.IClientCredentialTokenService _clientCredentialTokenService;

        public ClientCredentialTokenHandler(YellowPagesUI.Services.Interfaces.IClientCredentialTokenService clientCredentialTokenService)
        {
            _clientCredentialTokenService = clientCredentialTokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await _clientCredentialTokenService.GetToken());

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new YellowPagesUI.Exceptions.UnAuthorizeException();
            }

            return response;
        }
    }
}