using Microsoft.Extensions.Options;
using YellowPages.Data.Abstract;
using YellowPages.Shared.Models;
using YellowPages.Shared.Settings;


namespace YellowPages.Data.Concrete
{
    public class YellowPagesReportDal: MongoDbRepositoryBase<YellowPagesReport>, IYellowPagesReportDal
    {
        public YellowPagesReportDal(IOptions<DatabaseSettings> options) : base(options)
        {
        }
    }
}
