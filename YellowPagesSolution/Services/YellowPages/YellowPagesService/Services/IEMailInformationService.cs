using YellowPagesService.Dtos;

namespace YellowPagesService.Services;

public interface IEMailInformationService
{
    Task<YellowPages.Shared.Dtos.Response<EMailInformationDto>> CreateAsync(
        EMailInformationCreateDto eMailInformationCreateDto);

    Task<YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>> DeleteAsync(string id);
}