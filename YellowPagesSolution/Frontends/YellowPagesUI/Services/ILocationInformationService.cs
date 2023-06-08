namespace YellowPagesUI.Services;

public interface ILocationInformationService

{
    Task<bool> CreateAsync(YellowPagesUI.Models.LocationInformation.LocationInformationCreateDto locationInformationCreateDto);

    Task<bool> DeleteAsync(string id);
}