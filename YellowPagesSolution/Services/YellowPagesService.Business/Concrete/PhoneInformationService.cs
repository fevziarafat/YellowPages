﻿using YellowPages.Data.Abstract;
using YellowPages.Data.Concrete;
using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;
using YellowPagesService.Business.Abstract;
using IMongoCollectionExtensions = MongoDB.Driver.IMongoCollectionExtensions;

namespace YellowPagesService.Business.Concrete;

public class PhoneInformationService : IPhoneInformationService
{

    private readonly IPhoneInformationDal _phoneInformationDal;

    private readonly AutoMapper.IMapper _mapper;

    //private readonly MongoDB.Driver.IMongoCollection<PhoneInformation>
    //    _phoneInformationCollection;

    public PhoneInformationService(AutoMapper.IMapper mapper,
        YellowPages.Shared.Settings.IDatabaseSettings databaseSettings, IPhoneInformationDal phoneInformationDal)
    {
        //var client = new MongoDB.Driver.MongoClient(databaseSettings.ConnectionString);

        //var database = client.GetDatabase(databaseSettings.DatabaseName);

        //_phoneInformationCollection =
        //    database.GetCollection<PhoneInformation>(databaseSettings
        //        .PhoneInformationCollectionName);

        _mapper = mapper;
        _phoneInformationDal = phoneInformationDal;
    }

    public async Task<YellowPages.Shared.Dtos.Response<PhoneInformationDto>> CreateAsync(
        PhoneInformationCreateDto phoneInformationCreateDto)
    {
        var model = _mapper.Map<PhoneInformation>(phoneInformationCreateDto);
        
        var phones = _phoneInformationDal.Get().ToList();

        //var phones =
        //    await MongoDB.Driver.IAsyncCursorSourceExtensions.ToListAsync(
        //        IMongoCollectionExtensions.Find(_phoneInformationCollection, a => true));

        if (!phones.Any())
        {
            await _phoneInformationDal.AddAsync(model);
            //await _phoneInformationCollection.InsertOneAsync(model);
            return YellowPages.Shared.Dtos.Response<PhoneInformationDto>.Success(
                _mapper.Map<PhoneInformationDto>(model), 200);
        }

        var phoneX = phones.Where(x => x.Phone == model.Phone&& x.ContactId==model.ContactId);

        if (!phoneX.Any())
        {
            await _phoneInformationDal.AddAsync(model);
            //await _phoneInformationCollection.InsertOneAsync(model);
            return YellowPages.Shared.Dtos.Response<PhoneInformationDto>.Success(
                _mapper.Map<PhoneInformationDto>(model), 200);
        }

        return YellowPages.Shared.Dtos.Response<PhoneInformationDto>.Fail(
            "Can not added", 404);



    }


    public async Task<YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>> DeleteAsync(string id)
    {
        var result = await _phoneInformationDal.DeleteAsync(x => x.Id == id);
        //var result = await IMongoCollectionExtensions.DeleteOneAsync(_phoneInformationCollection, x => x.Id == id);

        if (result.ContactId != null)
            return YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>.Success(204);
        return YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>.Fail("Phone not found", 404);
    }
}