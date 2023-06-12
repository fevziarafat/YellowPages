using YellowPages.Shared.Dtos;

namespace YellowPagesUI.Services;

public interface IEMailInformationService
{
    Task<bool> CreateAsync(
        EMailInformationCreateDto eMailInformationCreateDto);

    Task<bool> DeleteAsync(string id);
}