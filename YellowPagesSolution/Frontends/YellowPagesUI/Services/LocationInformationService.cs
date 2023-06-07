

namespace YellowPagesUI.Services
{
    public class LocationInformationService : ILocationInformationService
    {
        private readonly HttpClient _httpClient;

        public LocationInformationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> CreateAsync(YellowPagesUI.Models.PhoneInformation.LocationInformationCreateDto locationInformationCreateDto)
        {
            var response = await _httpClient.PostAsJsonAsync<YellowPagesUI.Models.PhoneInformation.LocationInformationCreateDto>("locations", locationInformationCreateDto);

            return response.IsSuccessStatusCode;
        }

    

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"locations/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
