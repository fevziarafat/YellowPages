using YellowPagesService.Dtos;

namespace YellowPages.Services;

public interface IPhoneInformationService
{
    Task<YellowPages.Shared.Dtos.Response<PhoneInformationDto>> CreateAsync(
        PhoneInformationCreateDto phoneInformationCreateDto);

    Task<YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>> DeleteAsync(string id);
}