

using YellowPagesReportService.Dtos;

namespace YellowPagesReportService.Services;

public interface IYellowPagesReportService
{

    Task<YellowPages.Shared.Dtos.Response<YellowPagesReportDto>> CreateAsync(
        string locationName);
    Task<YellowPages.Shared.Dtos.Response<List<YellowPagesReportDto>>> GetAllAsync();

    Task<YellowPages.Shared.Dtos.Response<List<YellowPagesReportDto>>> GetReportByIdAsync(string id);

}