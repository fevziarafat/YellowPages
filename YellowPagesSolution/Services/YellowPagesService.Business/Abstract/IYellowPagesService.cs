using YellowPages.Shared.Dtos;

namespace YellowPagesService.Business.Abstract;

public interface IYellowPagesService
{
    Task<YellowPages.Shared.Dtos.Response<YellowPagesDto>> CreateAsync(
        YellowPagesCreateDto yellowPagesCreateDto);

    Task<YellowPages.Shared.Dtos.Response<List<YellowPagesDto>>> GetAllAsync();
    Task<YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>> DeleteAsync(string id);

    Task<YellowPages.Shared.Dtos.Response<YellowPagesDto>> GetAllInformationByUserIdAsync(string id);
}