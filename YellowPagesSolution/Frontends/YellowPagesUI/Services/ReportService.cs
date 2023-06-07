

namespace YellowPagesUI.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _httpClient;

        public ReportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<YellowPagesUI.Models.Report.ReportDto>> GetAllReportAsync()
        {
            var response = await _httpClient.GetAsync("ContactsReport");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<YellowPages.Shared.Dtos.Response<List<YellowPagesUI.Models.Report.ReportDto>>>();

            return responseSuccess.Data;
        }

    }
}
