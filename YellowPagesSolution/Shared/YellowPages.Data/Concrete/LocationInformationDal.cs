using Microsoft.Extensions.Options;
using YellowPages.Data.Abstract;
using YellowPages.Shared.Models;
using YellowPages.Shared.Settings;


namespace YellowPages.Data.Concrete
{
    public class LocationInformationDal : MongoDbRepositoryBase<LocationInformation>, ILocationInformationDal
    {
        public LocationInformationDal(IOptions<DatabaseSettings> options) : base(options)
        {
        }
    }
}
