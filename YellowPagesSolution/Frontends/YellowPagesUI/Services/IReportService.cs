

using YellowPages.Shared.Dtos;

namespace YellowPagesUI.Services
{
    public interface IReportService
    {
        Task<List<ReportDto>> GetAllReportAsync();
        Task<ReportDto> ReportById(string id);

    }
}