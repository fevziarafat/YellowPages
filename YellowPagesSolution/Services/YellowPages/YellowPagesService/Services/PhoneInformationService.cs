
using YellowPagesService.Dtos;
using IMongoCollectionExtensions = MongoDB.Driver.IMongoCollectionExtensions;

namespace YellowPages.Services;

public class PhoneInformationService : IPhoneInformationService
{
    private readonly AutoMapper.IMapper _mapper;

    private readonly MongoDB.Driver.IMongoCollection<YellowPagesService.Models.PhoneInformation>
        _phoneInformationCollection;

    public PhoneInformationService(AutoMapper.IMapper mapper,
        YellowPages.Shared.Settings.IDatabaseSettings databaseSettings)
    {
        var client = new MongoDB.Driver.MongoClient(databaseSettings.ConnectionString);

        var database = client.GetDatabase(databaseSettings.DatabaseName);

        _phoneInformationCollection =
            database.GetCollection<YellowPagesService.Models.PhoneInformation>(databaseSettings
                .PhoneInformationCollectionName);

        _mapper = mapper;
    }

    public async Task<Shared.Dtos.Response<PhoneInformationDto>> CreateAsync(
        PhoneInformationCreateDto phoneInformationCreateDto)
    {
        var model = _mapper.Map<YellowPagesService.Models.PhoneInformation>(phoneInformationCreateDto);


        var phones =
            await MongoDB.Driver.IAsyncCursorSourceExtensions.ToListAsync(
                IMongoCollectionExtensions.Find(_phoneInformationCollection, a => true));

        if (!phones.Any())
        {
            await _phoneInformationCollection.InsertOneAsync(model);
            return Shared.Dtos.Response<PhoneInformationDto>.Success(
                _mapper.Map<PhoneInformationDto>(model), 200);
        }

        var phoneX = phones.Where(x => x.Phone == model.Phone&& x.ContactId==model.ContactId);

        if (!phoneX.Any())
        {
            await _phoneInformationCollection.InsertOneAsync(model);
            return Shared.Dtos.Response<PhoneInformationDto>.Success(
                _mapper.Map<PhoneInformationDto>(model), 200);
        }

        return Shared.Dtos.Response<PhoneInformationDto>.Fail(
            "Can not added", 404);



    }


    public async Task<Shared.Dtos.Response<Shared.Dtos.NoContent>> DeleteAsync(string id)
    {
        var result = await IMongoCollectionExtensions.DeleteOneAsync(_phoneInformationCollection, x => x.Id == id);

        if (result.DeletedCount > 0)
            return Shared.Dtos.Response<Shared.Dtos.NoContent>.Success(204);
        return Shared.Dtos.Response<Shared.Dtos.NoContent>.Fail("Phone not found", 404);
    }
}