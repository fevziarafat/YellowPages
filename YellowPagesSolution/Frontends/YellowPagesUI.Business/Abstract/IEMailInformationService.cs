using YellowPages.Shared.Dtos;

namespace YellowPagesUI.Business.Abstract;

public interface IEMailInformationService
{
    Task<bool> CreateAsync(
        EMailInformationCreateDto eMailInformationCreateDto);

    Task<bool> DeleteAsync(string id);
}