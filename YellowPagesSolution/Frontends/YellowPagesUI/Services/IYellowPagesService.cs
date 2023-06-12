

using YellowPages.Shared.Dtos;

namespace YellowPagesUI.Services
{
    public interface IYellowPagesService
    {

        Task<bool> DeleteAsync(string id);
        Task<bool> CreateAsync(YellowPagesCreateDto yellowPagesCreateDto);
         Task<List<YellowPagesDto>> GetAllContactAsync();

         Task<YellowPagesDto> GetByIdAsync(string id);

         Task<bool> AddReport(string location);
    }
}