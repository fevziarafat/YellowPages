using Microsoft.Extensions.Options;
using YellowPages.Data.Abstract;
using YellowPages.Shared.Models;
using YellowPages.Shared.Settings;


namespace YellowPages.Data.Concrete
{
    public class YellowPagesDal: MongoDbRepositoryBase<Shared.Models.YellowPage>, IYellowPagesDal
    {
        public YellowPagesDal(IOptions<DatabaseSettings> options) : base(options)
        {
        }
    }
}
