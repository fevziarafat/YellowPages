

using YellowPages.Shared.Models;

namespace YellowPagesUI.Business.Abstract
{
    public interface IIdentityService
    {
        Task<YellowPages.Shared.Dtos.Response<bool>> SignIn(SigninInput signinInput);

        Task<IdentityModel.Client.TokenResponse> GetAccessTokenByRefreshToken();

        Task RevokeRefreshToken();
    }
}