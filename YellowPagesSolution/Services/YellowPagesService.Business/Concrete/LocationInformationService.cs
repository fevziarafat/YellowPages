using MongoDB.Driver;

using YellowPages.Data.Abstract;
using YellowPages.Data.Concrete;
using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;
using YellowPagesService.Business.Abstract;
using IMongoCollectionExtensions = MongoDB.Driver.IMongoCollectionExtensions;

namespace YellowPagesService.Business.Concrete;

public class LocationInformationService : ILocationInformationService
{
    private readonly ILocationInformationDal _locationInformationDal;
    
    //private readonly MongoDB.Driver.IMongoCollection<LocationInformation>
    //    _locationInformationCollection;

    private readonly AutoMapper.IMapper _mapper;

    public LocationInformationService(AutoMapper.IMapper mapper,
        YellowPages.Shared.Settings.IDatabaseSettings databaseSettings, ILocationInformationDal locationInformationDal)
    {
        //var client = new MongoDB.Driver.MongoClient(databaseSettings.ConnectionString);

        //var database = client.GetDatabase(databaseSettings.DatabaseName);

        //_locationInformationCollection =
        //    database.GetCollection<LocationInformation>(databaseSettings
        //        .LocationInformationCollectionName);

        _mapper = mapper;
        _locationInformationDal = locationInformationDal;
    }

    public async Task<YellowPages.Shared.Dtos.Response<LocationInformationDto>> CreateAsync(
        LocationInformationCreateDto locationInformationCreateDto)
    {
        var model = _mapper.Map<LocationInformation>(locationInformationCreateDto);

        var locations = _locationInformationDal.Get().ToList();
        //var locations =
        //    await IAsyncCursorSourceExtensions.ToListAsync(
        //        IMongoCollectionExtensions.Find(_locationInformationCollection, a => true));

        if (!locations.Any())
        {
            await _locationInformationDal.AddAsync(model);
            //await _locationInformationCollection.InsertOneAsync(model);
            return YellowPages.Shared.Dtos.Response<LocationInformationDto>.Success(
                _mapper.Map<LocationInformationDto>(model), 200);
        }

        var locationX = locations.Where(x => x.Location == model.Location&& x.ContactId== model.ContactId);

        if (!locationX.Any())
        {
            await _locationInformationDal.AddAsync(model);
            //await _locationInformationCollection.InsertOneAsync(model);
            return YellowPages.Shared.Dtos.Response<LocationInformationDto>.Success(
                _mapper.Map<LocationInformationDto>(model), 200);
        }
        return YellowPages.Shared.Dtos.Response<LocationInformationDto>.Fail(
            "Can not added ", 404);

    }


    public async Task<YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>> DeleteAsync(string id)
    {
        var result = await _locationInformationDal.DeleteAsync(x => x.Id == id);
        //var result = await IMongoCollectionExtensions.DeleteOneAsync(_locationInformationCollection, x => x.Id == id);

        if (result.ContactId!=null)
            return YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>.Success(204);
        return YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>.Fail("Location not found", 404);
    }
}