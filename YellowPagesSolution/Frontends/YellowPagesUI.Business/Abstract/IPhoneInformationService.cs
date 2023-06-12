
using YellowPages.Shared.Dtos;

namespace YellowPagesUI.Business.Abstract;

public interface IPhoneInformationService
{
    Task<bool> CreateAsync(
       PhoneInformationCreateDto phoneInformationCreateDto);

    Task<bool> DeleteAsync(string id);
}