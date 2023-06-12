

using YellowPages.Shared.Models;

namespace YellowPagesUI.Business.Abstract
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();
    }
}