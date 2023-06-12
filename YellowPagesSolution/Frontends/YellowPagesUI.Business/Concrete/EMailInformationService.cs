using System.Net.Http.Json;
using YellowPages.Shared.Dtos;
using YellowPagesUI.Business.Abstract;

namespace YellowPagesUI.Business.Concrete
{
    public class EMailInformationService : IEMailInformationService
    {
        private readonly HttpClient _httpClient;

        public EMailInformationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> CreateAsync(EMailInformationCreateDto eMailInformationCreateDto)
        {
            var response = await _httpClient.PostAsJsonAsync<EMailInformationCreateDto>("emails", eMailInformationCreateDto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"emails/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
