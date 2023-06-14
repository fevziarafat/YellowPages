using MongoDB.Driver;
using YellowPages.Data.Abstract;
using YellowPages.Data.Concrete;
using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;
using YellowPagesService.Business.Abstract;

namespace YellowPagesService.Business.Concrete;

public class EMailInformationService : IEMailInformationService
{
    private readonly IEMailInformationDal _eMailInformationDal;
    //private readonly MongoDB.Driver.IMongoCollection<EMailInformation>
    //    _eMailInformationCollection;

    private readonly AutoMapper.IMapper _mapper;

    public EMailInformationService(AutoMapper.IMapper mapper,
        YellowPages.Shared.Settings.IDatabaseSettings databaseSettings, IEMailInformationDal eMailInformationDal)
    {
        //var client = new MongoDB.Driver.MongoClient(databaseSettings.ConnectionString);

        //var database = client.GetDatabase(databaseSettings.DatabaseName);

        //_eMailInformationCollection =
        //    database.GetCollection<EMailInformation>(databaseSettings
        //        .EMailInformationCollectionName);

        _mapper = mapper;
        _eMailInformationDal = eMailInformationDal;
    }

    public async Task<YellowPages.Shared.Dtos.Response<EMailInformationDto>> CreateAsync(
        EMailInformationCreateDto eMailInformationCreateDto)
    {
        var model = _mapper.Map<EMailInformation>(eMailInformationCreateDto);

        var eMails = _eMailInformationDal.Get().ToList();



        if (!eMails.Any())
        {
            await _eMailInformationDal.AddAsync(model);
            //await _eMailInformationCollection.InsertOneAsync(model);
            return YellowPages.Shared.Dtos.Response<EMailInformationDto>.Success(
                _mapper.Map<EMailInformationDto>(model), 200);
        }
        var eMailX = eMails.Where(x => x.EMail == model.EMail && x.ContactId == model.ContactId);

        if (!eMailX.Any())
        {
            //await _eMailInformationCollection.InsertOneAsync(model);

            await _eMailInformationDal.AddAsync(model);
            return YellowPages.Shared.Dtos.Response<EMailInformationDto>.Success(
                _mapper.Map<EMailInformationDto>(model), 200);
        }
        return YellowPages.Shared.Dtos.Response<EMailInformationDto>.Fail(
            "Can not added ", 404);

    }


    public async Task<YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>> DeleteAsync(string id)
    {

        var result= await _eMailInformationDal.DeleteAsync(x => x.Id == id);
        //var result = await IMongoCollectionExtensions.DeleteOneAsync(_eMailInformationCollection, x => x.Id == id);

        if (result.EMail!=null)
            return YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>.Success(204);
        return YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>.Fail("Contact not found", 404);
    }
}