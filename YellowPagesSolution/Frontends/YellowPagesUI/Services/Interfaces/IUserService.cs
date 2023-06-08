

namespace YellowPagesUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<YellowPagesUI.Models.UserViewModel> GetUser();
    }
}