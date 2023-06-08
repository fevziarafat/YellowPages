

namespace YellowPagesUI.Services
{
    public class YellowPagesService : IYellowPagesService
    {
        private readonly HttpClient _httpClient;

        public YellowPagesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> CreateAsync(YellowPagesUI.Models.YellowPages.YellowPagesCreateDto yellowPagesCreateDto)
        {
            var response = await _httpClient.PostAsJsonAsync<YellowPagesUI.Models.YellowPages.YellowPagesCreateDto>("yellowpages", yellowPagesCreateDto)
                ;

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"yellowpages/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<YellowPagesUI.Models.YellowPages.YellowPagesDto>> GetAllContactAsync()
        {
            var response = await _httpClient.GetAsync("yellowpages");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<YellowPages.Shared.Dtos.Response<List<YellowPagesUI.Models.YellowPages.YellowPagesDto>>>();

            return responseSuccess.Data;
        }

        public async Task<YellowPagesUI.Models.YellowPages.YellowPagesDto> GetByIdAsync(string id)
        {

            var yellowpages = await _httpClient.GetAsync($"yellowpages/GetAllInformationByUserId/{id}");
            //var contacts = await GetByIdAsync(id);

            if (yellowpages == null)

            {
                return null;
            }
            else
            {

                 var response= await yellowpages.Content.ReadFromJsonAsync<YellowPages.Shared.Dtos.Response<YellowPagesUI.Models.YellowPages.YellowPagesDto>>();
                 return response.Data;
            }

        }

        [Microsoft.AspNetCore.Mvc.HttpPostAttribute]
        public async Task<bool> AddReport(string location)
        {
            var yellowpages = await _httpClient.PostAsJsonAsync($"yellowpages/ReceiveReport/{location}", location);

            if (yellowpages == null)

            {
                return false;
            }
            else
            {

                var response = await yellowpages.Content.ReadFromJsonAsync<YellowPages.Shared.Dtos.Response<YellowPagesUI.Models.YellowPages.YellowPagesDto>>();
                return true;
            }

        }
    }
}
