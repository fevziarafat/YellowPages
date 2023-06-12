using YellowPages.Shared.Dtos;

namespace YellowPagesService.Business.Abstract;

public interface ILocationInformationService
{
    Task<YellowPages.Shared.Dtos.Response<LocationInformationDto>> CreateAsync(
        LocationInformationCreateDto locationInformationCreateDto);

    Task<YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>> DeleteAsync(string id);
}