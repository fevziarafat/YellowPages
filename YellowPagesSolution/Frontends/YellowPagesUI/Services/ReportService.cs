

using YellowPagesUI.Models.Report;

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
            var response = await _httpClient.GetAsync("yellowpagesreport/GetAllReport");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<YellowPages.Shared.Dtos.Response<List<YellowPagesUI.Models.Report.ReportDto>>>();

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
