using Microsoft.Extensions.Options;
using YellowPages.Data.Abstract;
using YellowPages.Shared.Models;
using YellowPages.Shared.Settings;


namespace YellowPages.Data.Concrete
{
    public class EMailInformationDal : MongoDbRepositoryBase<EMailInformation>, IEMailInformationDal
    {
        public EMailInformationDal(IOptions<DatabaseSettings> options) : base(options)
        {
        }
    }
}
