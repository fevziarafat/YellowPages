using System.Net.Http.Json;
using YellowPages.Shared.Dtos;
using YellowPagesUI.Business.Abstract;

namespace YellowPagesUI.Business.Concrete
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _httpClient;

        public ReportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ReportDto>> GetAllReportAsync()
        {
            var response = await _httpClient.GetAsync("yellowpagesreport/GetAllReport");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<YellowPages.Shared.Dtos.Response<List<ReportDto>>>();

            return responseSuccess.Data;
        }

        public async Task<ReportDto> ReportById(string id)
        {
            var report = await _httpClient.GetAsync($"yellowpagesreport/ReportById/{id}");
            //var contacts = await GetByIdAsync(id);

            if (report == null)

            {
                return null;
            }
            else
            {

                var response = await report.Content.ReadFromJsonAsync<YellowPages.Shared.Dtos.Response<ReportDto>>();
                return response.Data;
            }

        }
    }
}
