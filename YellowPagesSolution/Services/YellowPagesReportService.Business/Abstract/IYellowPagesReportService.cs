

using YellowPages.Shared.Dtos;

namespace YellowPagesReportService.Business.Abstract;

public interface IYellowPagesReportService
{

    Task<YellowPages.Shared.Dtos.Response<YellowPagesReportDto>> CreateAsync(
        string locationName);
    Task<YellowPages.Shared.Dtos.Response<List<YellowPagesReportDto>>> GetAllAsync();

    //Task<YellowPages.Shared.Dtos.Response<List<YellowPagesReportDto>>> GetReportByIdAsync(string id);

    Task<YellowPages.Shared.Dtos.Response<YellowPagesReportDto>> GetReportByIdAsync(string id);
}