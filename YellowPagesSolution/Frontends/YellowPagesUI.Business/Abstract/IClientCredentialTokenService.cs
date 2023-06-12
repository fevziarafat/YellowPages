

namespace YellowPagesUI.Business.Abstract
{
    public interface IClientCredentialTokenService
    {
        Task<String> GetToken();
    }
}