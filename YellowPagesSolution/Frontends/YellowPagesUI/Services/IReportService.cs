

namespace YellowPagesUI.Services
{
    public interface IReportService
    {
        Task<List<YellowPagesUI.Models.Report.ReportDto>> GetAllReportAsync();
        Task<YellowPagesUI.Models.Report.ReportDto> ReportById(string id);

    }
}