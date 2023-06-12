
using YellowPages.Shared.Dtos;

namespace YellowPagesUI.Services;

public interface IPhoneInformationService
{
    Task<bool> CreateAsync(
       PhoneInformationCreateDto phoneInformationCreateDto);

    Task<bool> DeleteAsync(string id);
}