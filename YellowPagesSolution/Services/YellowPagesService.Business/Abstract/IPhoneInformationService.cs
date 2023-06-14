using YellowPages.Shared.Dtos;

namespace YellowPagesService.Business.Abstract;

public interface IPhoneInformationService
{
    Task<Response<PhoneInformationDto>> CreateAsync(
        PhoneInformationCreateDto phoneInformationCreateDto);

    Task<Response<NoContent>> DeleteAsync(string id);
}