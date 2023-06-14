

using YellowPages.Data.Abstract;
using YellowPages.Data.Concrete;
using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;
using YellowPagesReportService.Business.Abstract;

namespace YellowPagesReportService.Business.Concrete;

public class YellowPagesReportService : IYellowPagesReportService
{

    private readonly IPhoneInformationDal _phoneInformationDal;

    private readonly ILocationInformationDal _locationInformationDal;

    private readonly IEMailInformationDal _eMailInformationDal;
    private readonly IYellowPagesDal _yellowPagesDal;
    private readonly IYellowPagesReportDal _yellowPagesReportDal;




    //private readonly MongoDB.Driver.IMongoCollection<LocationInformation>
    //    _locationInformationCollection;

    private readonly AutoMapper.IMapper _mapper;

    //private readonly MongoDB.Driver.IMongoCollection<PhoneInformation>
    //    _phoneInformationCollection;

    //private readonly MongoDB.Driver.IMongoCollection<YellowPages.Shared.Models.YellowPage> _yellowPagesCollection;

    //private readonly MongoDB.Driver.IMongoCollection<YellowPagesReport> _yellowPagesReportCollection;

    public YellowPagesReportService(AutoMapper.IMapper mapper,
        YellowPages.Shared.Settings.IDatabaseSettings databaseSettings, IPhoneInformationDal phoneInformationDal, ILocationInformationDal locationInformationDal, IEMailInformationDal eMailInformationDal, IYellowPagesDal yellowPagesDal, IYellowPagesReportDal yellowPagesReportDal)
    {
        var client = new MongoDB.Driver.MongoClient(databaseSettings.ConnectionString);

        var database = client.GetDatabase(databaseSettings.DatabaseName);

        //_yellowPagesCollection =
        //    database.GetCollection<YellowPages.Shared.Models.YellowPage>(databaseSettings.YellowPagesCollectionName);


        //_yellowPagesReportCollection =
        //    database.GetCollection<YellowPagesReport>(databaseSettings.YellowPagesReportCollectionName);


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
        _yellowPagesReportDal = yellowPagesReportDal;
    }

    //Rapor oluşturma
    public async Task<YellowPages.Shared.Dtos.Response<YellowPagesReportDto>> CreateAsync(
        string locationName)
    {
        var yellowReportCreateDto = new YellowPagesReportCreateDto();
        yellowReportCreateDto.Location = locationName;
        var model = _mapper.Map<YellowPagesReport>(yellowReportCreateDto);

        //var locations =
        //    await MongoDB.Driver.IAsyncCursorSourceExtensions.ToListAsync(
        //        MongoDB.Driver.IMongoCollectionExtensions.Find(_locationInformationCollection, a => true));

        var locations = _locationInformationDal.Get().ToList();
        var yellowPages = _yellowPagesDal.Get().ToList();
        var phones = _phoneInformationDal.Get().ToList();

        //var yellowPages =
        //    await MongoDB.Driver.IAsyncCursorSourceExtensions.ToListAsync(
        //        MongoDB.Driver.IMongoCollectionExtensions.Find(_yellowPagesCollection, a => true));

        //var phones = await MongoDB.Driver.IAsyncCursorSourceExtensions.ToListAsync(
        //    MongoDB.Driver.IMongoCollectionExtensions.Find(_phoneInformationCollection, a => true));

        var yellowPagesCount = 0;
        var phoneCount = 0;
        var contactGuidList = new List<string>();

        if (locations.Any())
            foreach (var location in locations)
                if (location.Location == yellowReportCreateDto.Location)
                {
                    var personId = location.ContactId;

                    foreach (var contact in yellowPages)
                        if (contact.Id == personId)
                            if (!contactGuidList.Contains(personId))
                            {
                                contactGuidList.Add(personId);
                                yellowPagesCount++;
                            }

                    foreach (var phone in phones)
                        if (phone.ContactId == personId)
                            phoneCount++;
                }

        model.Location = yellowReportCreateDto.Location;
        model.LocationContactCount = yellowPagesCount;
        model.LocationPhoneCount = phoneCount;
        model.CreatedTime = DateTime.Now;


        await _yellowPagesReportDal.AddAsync(model);
        //await _yellowPagesReportCollection.InsertOneAsync(model);
        return YellowPages.Shared.Dtos.Response<YellowPagesReportDto>.Success(
            _mapper.Map<YellowPagesReportDto>(model), 200);
    }

    //Rapor listelenmesi
    public async Task<YellowPages.Shared.Dtos.Response<List<YellowPagesReportDto>>> GetAllAsync()
    {
        //var yellowReports =
        //    await MongoDB.Driver.IAsyncCursorSourceExtensions.ToListAsync(
        //        MongoDB.Driver.IMongoCollectionExtensions.Find(_yellowPagesReportCollection, contact => true));
       
        var yellowReports = _yellowPagesReportDal.Get().ToList();

        return YellowPages.Shared.Dtos.Response<List<YellowPagesReportDto>>.Success(
            _mapper.Map<List<YellowPagesReportDto>>(yellowReports), 200);
    }

    public async Task<YellowPages.Shared.Dtos.Response<YellowPagesReportDto>> GetReportByIdAsync(string id)
    {
        //var yellowReports =
        //    await MongoDB.Driver.IAsyncCursorSourceExtensions.ToListAsync(
        //        MongoDB.Driver.IMongoCollectionExtensions.Find(_yellowPagesReportCollection, x => x.Id == id));


        var yellowReports= _yellowPagesReportDal.Get(x=>x.Id==id).FirstOrDefault();
        return YellowPages.Shared.Dtos.Response<YellowPagesReportDto>.Success(
            _mapper.Map<YellowPagesReportDto>(yellowReports), 200);
    }

}