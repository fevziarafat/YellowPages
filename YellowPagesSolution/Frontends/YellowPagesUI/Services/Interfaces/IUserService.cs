

using YellowPages.Shared.Models;

namespace YellowPagesUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();
    }
}