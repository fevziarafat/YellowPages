using YellowPages.Shared.Dtos;

namespace YellowPagesService.Business.Abstract;

public interface IYellowPagesService
{
    Task<Response<YellowPagesDto>> CreateAsync(
        YellowPagesCreateDto yellowPagesCreateDto);

    Task<Response<List<YellowPagesDto>>> GetAllAsync();
    Task<Response<NoContent>> DeleteAsync(string id);

    Task<Response<YellowPagesDto>> GetAllInformationByUserIdAsync(string id);
}