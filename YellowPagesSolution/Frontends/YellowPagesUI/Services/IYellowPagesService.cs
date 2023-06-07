

namespace YellowPagesUI.Services
{
    public interface IYellowPagesService
    {

        Task<bool> DeleteAsync(string id);
        Task<bool> CreateAsync(YellowPagesUI.Models.YellowPages.YellowPagesCreateDto yellowPagesCreateDto);
         Task<List<YellowPagesUI.Models.YellowPages.YellowPagesDto>> GetAllContactAsync();

         Task<YellowPagesUI.Models.YellowPages.YellowPagesDto> GetByIdAsync(string id);

         Task<bool> AddReport(string location);
    }
}