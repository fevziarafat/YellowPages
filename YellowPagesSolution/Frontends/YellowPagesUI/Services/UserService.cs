

namespace YellowPagesUI.Services
{
    public class UserService : YellowPagesUI.Services.Interfaces.IUserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<YellowPagesUI.Models.UserViewModel> GetUser()
        {
            return await _client.GetFromJsonAsync<YellowPagesUI.Models.UserViewModel>("/api/user/getuser");
        }
    }
}