using MongoDB.Driver;
using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;
using YellowPagesService.Business.Abstract;

namespace YellowPagesService.Business.Concrete;

public class EMailInformationService : IEMailInformationService
{
    private readonly MongoDB.Driver.IMongoCollection<EMailInformation>
        _eMailInformationCollection;

    private readonly AutoMapper.IMapper _mapper;

    public EMailInformationService(AutoMapper.IMapper mapper,
        YellowPages.Shared.Settings.IDatabaseSettings databaseSettings)
    {
        var client = new MongoDB.Driver.MongoClient(databaseSettings.ConnectionString);

        var database = client.GetDatabase(databaseSettings.DatabaseName);

        _eMailInformationCollection =
            database.GetCollection<EMailInformation>(databaseSettings
                .EMailInformationCollectionName);

        _mapper = mapper;
    }

    public async Task<YellowPages.Shared.Dtos.Response<EMailInformationDto>> CreateAsync(
        EMailInformationCreateDto eMailInformationCreateDto)
    {
        var model = _mapper.Map<EMailInformation>(eMailInformationCreateDto);

        var eMails =
            await MongoDB.Driver.IAsyncCursorSourceExtensions.ToListAsync(
                IMongoCollectionExtensions.Find(_eMailInformationCollection, a => true));

        if (!eMails.Any())
        {
            await _eMailInformationCollection.InsertOneAsync(model);
            return YellowPages.Shared.Dtos.Response<EMailInformationDto>.Success(
                _mapper.Map<EMailInformationDto>(model), 200);
        }
        var eMailX = eMails.Where(x => x.EMail == model.EMail && x.ContactId == model.ContactId);

        if (!eMailX.Any())
        {
            await _eMailInformationCollection.InsertOneAsync(model);
            return YellowPages.Shared.Dtos.Response<EMailInformationDto>.Success(
                _mapper.Map<EMailInformationDto>(model), 200);
        }
        return YellowPages.Shared.Dtos.Response<EMailInformationDto>.Fail(
            "Can not added ", 404);

    }


    public async Task<YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>> DeleteAsync(string id)
    {
        var result = await IMongoCollectionExtensions.DeleteOneAsync(_eMailInformationCollection, x => x.Id == id);

        if (result.DeletedCount > 0)
            return YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>.Success(204);
        return YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>.Fail("Contact not found", 404);
    }
}