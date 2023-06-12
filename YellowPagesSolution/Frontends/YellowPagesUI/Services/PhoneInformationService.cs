

using YellowPages.Shared.Dtos;

namespace YellowPagesUI.Services
{
    public class PhoneInformationService : IPhoneInformationService
    {
        private readonly HttpClient _httpClient;

        public PhoneInformationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> CreateAsync(PhoneInformationCreateDto phoneInformationCreateDto)
        {
            var response = await _httpClient.PostAsJsonAsync<PhoneInformationCreateDto>("phones", phoneInformationCreateDto);

            return response.IsSuccessStatusCode;
        }


        public async Task<bool> DeleteAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"phones/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
