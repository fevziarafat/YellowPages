using YellowPages.Shared.Dtos;

namespace YellowPagesUI.Business.Abstract;

public interface ILocationInformationService

{
    Task<bool> CreateAsync(LocationInformationCreateDto locationInformationCreateDto);

    Task<bool> DeleteAsync(string id);
}