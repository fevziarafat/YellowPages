
namespace YellowPagesUI.Services;

public interface IPhoneInformationService
{
    Task<bool> CreateAsync(
       YellowPagesUI.Models.PhoneInformation.PhoneInformationCreateDto phoneInformationCreateDto);

    Task<bool> DeleteAsync(string id);
}