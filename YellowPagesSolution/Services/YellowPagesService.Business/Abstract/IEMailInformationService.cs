using YellowPages.Shared.Dtos;

namespace YellowPagesService.Business.Abstract;

public interface IEMailInformationService
{
    Task<Response<EMailInformationDto>> CreateAsync(
        EMailInformationCreateDto eMailInformationCreateDto);

    Task<Response<NoContent>> DeleteAsync(string id);
}