namespace YellowPagesUI.Services;

public interface IEMailInformationService
{
    Task<bool> CreateAsync(
        YellowPagesUI.Models.EMailInformations.EMailInformationCreateDto eMailInformationCreateDto);

    Task<bool> DeleteAsync(string id);
}