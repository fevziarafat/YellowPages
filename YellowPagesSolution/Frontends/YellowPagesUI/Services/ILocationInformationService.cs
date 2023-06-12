using YellowPages.Shared.Dtos;

namespace YellowPagesUI.Services;

public interface ILocationInformationService

{
    Task<bool> CreateAsync(LocationInformationCreateDto locationInformationCreateDto);

    Task<bool> DeleteAsync(string id);
}