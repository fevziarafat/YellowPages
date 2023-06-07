namespace YellowPagesUI.Services;

public interface ILocationInformationService

{
    Task<bool> CreateAsync(YellowPagesUI.Models.PhoneInformation.LocationInformationCreateDto locationInformationCreateDto);

    Task<bool> DeleteAsync(string id);
}