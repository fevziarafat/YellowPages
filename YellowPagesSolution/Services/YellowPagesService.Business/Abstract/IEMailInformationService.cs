

using YellowPages.Shared.Dtos;

namespace YellowPagesService.Business.Abstract
{
public interface IEMailInformationService
{
    Task<Response<EMailInformationDto>> CreateAsync(
        EMailInformationCreateDto eMailInformationCreateDto);

    Task<YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>> DeleteAsync(string id);
}
}