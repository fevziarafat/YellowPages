using YellowPages.Shared.Dtos;

namespace YellowPagesReportService.Business.Abstract;

public interface IYellowPagesReportService
{
    Task<Response<YellowPagesReportDto>> CreateAsync(
        string locationName);

    Task<Response<List<YellowPagesReportDto>>> GetAllAsync();

    Task<Response<YellowPagesReportDto>> GetReportByIdAsync(string id);
}