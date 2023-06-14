using YellowPages.Shared.Dtos;

namespace YellowPagesService.Business.Abstract;

public interface ILocationInformationService
{
    Task<Response<LocationInformationDto>> CreateAsync(
        LocationInformationCreateDto locationInformationCreateDto);

    Task<Response<NoContent>> DeleteAsync(string id);
}