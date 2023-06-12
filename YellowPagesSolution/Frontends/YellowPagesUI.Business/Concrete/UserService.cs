using System.Net.Http.Json;
using YellowPages.Shared.Models;
using YellowPagesUI.Business.Abstract;

namespace YellowPagesUI.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserViewModel> GetUser()
        {
            return await _client.GetFromJsonAsync<UserViewModel>("/api/user/getuser");
        }
    }
}