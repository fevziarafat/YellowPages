using YellowPages.Data.Abstract;
using YellowPages.Data.Concrete;
using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;
using YellowPages.Shared.Settings;
using YellowPagesService.Business.Abstract;
using EMailInformation = YellowPages.Shared.Models.EMailInformation;
using IAsyncCursorSourceExtensions = MongoDB.Driver.IAsyncCursorSourceExtensions;
using IFindFluentExtensions = MongoDB.Driver.IFindFluentExtensions;
using IMongoCollectionExtensions = MongoDB.Driver.IMongoCollectionExtensions;
using LocationInformation = YellowPages.Shared.Models.LocationInformation;
using Models_YellowPages = YellowPages.Shared.Models.YellowPage;
using PhoneInformation = YellowPages.Shared.Models.PhoneInformation;



namespace YellowPagesService.Business.Concrete;

public class YellowPagesService : IYellowPagesService
{
    private readonly IPhoneInformationDal _phoneInformationDal;
    
    private readonly ILocationInformationDal _locationInformationDal;

    private readonly IEMailInformationDal _eMailInformationDal;
    private readonly IYellowPagesDal _yellowPagesDal;

    //private readonly MongoDB.Driver.IMongoCollection<Models_YellowPages> _yellowPagesCollection;

    //private readonly MongoDB.Driver.IMongoCollection<EMailInformation> _eMailInformationCollection;

    //private readonly MongoDB.Driver.IMongoCollection<LocationInformation> _locationInformationCollection;

    //private readonly MongoDB.Driver.IMongoCollection<PhoneInformation> _phoneInformationCollection;

    private readonly AutoMapper.IMapper _mapper;

    public YellowPagesService(AutoMapper.IMapper mapper, IDatabaseSettings databaseSettings, IPhoneInformationDal phoneInformationDal, ILocationInformationDal locationInformationDal, IEMailInformationDal eMailInformationDal, IYellowPagesDal yellowPagesDal)
    {
        //var client = new MongoDB.Driver.MongoClient(databaseSettings.ConnectionString);

        //var database = client.GetDatabase(databaseSettings.DatabaseName);

        //_yellowPagesCollection =
        //    database.GetCollection<Models_YellowPages > (databaseSettings.YellowPagesCollectionName);

        //_eMailInformationCollection =
        //    database.GetCollection<EMailInformation>(databaseSettings
        //        .EMailInformationCollectionName);

        //_locationInformationCollection =
        //    database.GetCollection<LocationInformation>(databaseSettings
        //        .LocationInformationCollectionName);

        //_phoneInformationCollection =
        //    database.GetCollection<PhoneInformation>(databaseSettings
        //        .PhoneInformationCollectionName);

        _mapper = mapper;
        _phoneInformationDal = phoneInformationDal;
        _locationInformationDal = locationInformationDal;
        _eMailInformationDal = eMailInformationDal;
        _yellowPagesDal = yellowPagesDal;
    }

    //Rehberde kişi oluşturma
    public async Task<YellowPages.Shared.Dtos.Response<YellowPagesDto>> CreateAsync(
        YellowPagesCreateDto yellowPagesCreateDto)
    {
        var model = _mapper.Map<Models_YellowPages>(yellowPagesCreateDto);

        var contacts = _yellowPagesDal.Get().ToList();
        //var contacts =
        //    await IAsyncCursorSourceExtensions.ToListAsync(
        //        IMongoCollectionExtensions.Find(_yellowPagesCollection, a => true));

        if (!contacts.Any())
        {
            await _yellowPagesDal.AddAsync(model);
            //await _yellowPagesCollection.InsertOneAsync(model);
            return YellowPages.Shared.Dtos.Response<YellowPagesDto>.Success(
                _mapper.Map<YellowPagesDto>(model), 200);
        }
        var contactsX = contacts.Where(x => x.Name == model.Name);

        if (!contactsX.Any())
        {
            await _yellowPagesDal.AddAsync(model);
            //await _yellowPagesCollection.InsertOneAsync(model);
            return YellowPages.Shared.Dtos.Response<YellowPagesDto>.Success(
                _mapper.Map<YellowPagesDto>(model), 200);
        }
        return YellowPages.Shared.Dtos.Response<YellowPagesDto>.Fail(
            "Can not added ", 404);


    }

    //Rehberdeki kişilerin listelenmesi
    public async Task<YellowPages.Shared.Dtos.Response<List<YellowPagesDto>>> GetAllAsync()
    {
        //var yellowPages =
        //    await IAsyncCursorSourceExtensions.ToListAsync(
        //        IMongoCollectionExtensions.Find(_yellowPagesCollection, contact => true));

        var yellowPages =_yellowPagesDal.Get().ToList();

        if (yellowPages.Any())
            foreach (var yellowPage in yellowPages)
            {

                yellowPage.EMailInformation = _eMailInformationDal.Get(x => x.ContactId == yellowPage.Id).ToList();
                //yellowPage.EMailInformation = await IAsyncCursorSourceExtensions.ToListAsync(
                //    IMongoCollectionExtensions.Find(_eMailInformationCollection, x => x.ContactId == yellowPage.Id));

                yellowPage.LocationInformation = _locationInformationDal.Get(x => x.ContactId == yellowPage.Id).ToList();
                //yellowPage.LocationInformation = await IAsyncCursorSourceExtensions.ToListAsync(
                //    IMongoCollectionExtensions.Find(_locationInformationCollection, x => x.ContactId == yellowPage.Id));
                yellowPage.PhoneInformation = _phoneInformationDal.Get(x => x.ContactId == yellowPage.Id).ToList();

                //yellowPage.PhoneInformation = await IAsyncCursorSourceExtensions.ToListAsync(
                //    IMongoCollectionExtensions.Find(_phoneInformationCollection, x => x.ContactId == yellowPage.Id));
            }

        return YellowPages.Shared.Dtos.Response<List<YellowPagesDto>>.Success(
            _mapper.Map<List<YellowPagesDto>>(yellowPages), 200);
    }

    //Rehberde kişi kaldırma
    public async Task<YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>> DeleteAsync(string id)
    {

        var result = await _yellowPagesDal.DeleteAsync(x => x.Id == id);

        //var result = await IMongoCollectionExtensions.DeleteOneAsync(_yellowPagesCollection, x => x.Id == id);

        if (result.Id != null)
            return YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>.Success(204);
        return YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>.Fail("Contact not found", 404);
    }

    //Rehberdeki bir kişiye ait iletişim bilgilerinin de yer aldığı detay bilgilerinin getirilmesi
    public async Task<YellowPages.Shared.Dtos.Response<YellowPagesDto>>
        GetAllInformationByUserIdAsync(string id)
    {


        var contact = _yellowPagesDal.Get(x => x.Id == id).FirstOrDefault();
        //var contact =
        //    await IFindFluentExtensions.FirstAsync(IMongoCollectionExtensions.Find(_yellowPagesCollection,
        //        x => x.Id == id));


        //var eMailInformationCollections =
        //    await IAsyncCursorSourceExtensions.ToListAsync(
        //        IMongoCollectionExtensions.Find(_eMailInformationCollection, x => x.ContactId == id));

        var eMailInformationCollections = _eMailInformationDal.Get(x => x.ContactId == id).ToList();

        //var locationInformationCollection =
        //    await IAsyncCursorSourceExtensions.ToListAsync(
        //        IMongoCollectionExtensions.Find(_locationInformationCollection, x => x.ContactId == id));

        var locationInformationCollection = _locationInformationDal.Get(x => x.ContactId == id).ToList();

        //var phoneInformationCollection =
        //    await IAsyncCursorSourceExtensions.ToListAsync(
        //        IMongoCollectionExtensions.Find(_phoneInformationCollection, x => x.ContactId == id));

        var phoneInformationCollection = _phoneInformationDal.Get(x => x.ContactId == id).ToList();


        contact.EMailInformation = eMailInformationCollections;
        contact.LocationInformation = locationInformationCollection;
        contact.PhoneInformation = phoneInformationCollection;

        return YellowPages.Shared.Dtos.Response<YellowPagesDto>.Success(
            _mapper.Map<YellowPagesDto>(contact), 200);
    }
}