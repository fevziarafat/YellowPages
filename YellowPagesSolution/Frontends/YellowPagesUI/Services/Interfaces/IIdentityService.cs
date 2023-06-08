

namespace YellowPagesUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<YellowPages.Shared.Dtos.Response<bool>> SignIn(YellowPagesUI.Models.SigninInput signinInput);

        Task<IdentityModel.Client.TokenResponse> GetAccessTokenByRefreshToken();

        Task RevokeRefreshToken();
    }
}