using Microsoft.Extensions.Options;
using YellowPages.Data.Abstract;
using YellowPages.Shared.Models;
using YellowPages.Shared.Settings;


namespace YellowPages.Data.Concrete
{
    public class PhoneInformationDal : MongoDbRepositoryBase<PhoneInformation>, IPhoneInformationDal
    {
        public PhoneInformationDal(IOptions<DatabaseSettings> options) : base(options)
        {
        }
    }
}
