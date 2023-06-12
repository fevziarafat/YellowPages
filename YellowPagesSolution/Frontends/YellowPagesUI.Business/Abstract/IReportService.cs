

using YellowPages.Shared.Dtos;

namespace YellowPagesUI.Business.Abstract
{
    public interface IReportService
    {
        Task<List<ReportDto>> GetAllReportAsync();
        Task<ReportDto> ReportById(string id);

    }
}