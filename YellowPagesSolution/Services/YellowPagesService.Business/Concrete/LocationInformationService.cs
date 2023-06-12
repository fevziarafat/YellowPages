﻿using MongoDB.Driver;
using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;
using YellowPagesService.Business.Abstract;
using IMongoCollectionExtensions = MongoDB.Driver.IMongoCollectionExtensions;

namespace YellowPagesService.Business.Concrete;

public class LocationInformationService : ILocationInformationService
{
    private readonly MongoDB.Driver.IMongoCollection<LocationInformation>
        _locationInformationCollection;

    private readonly AutoMapper.IMapper _mapper;

    public LocationInformationService(AutoMapper.IMapper mapper,
        YellowPages.Shared.Settings.IDatabaseSettings databaseSettings)
    {
        var client = new MongoDB.Driver.MongoClient(databaseSettings.ConnectionString);

        var database = client.GetDatabase(databaseSettings.DatabaseName);

        _locationInformationCollection =
            database.GetCollection<LocationInformation>(databaseSettings
                .LocationInformationCollectionName);

        _mapper = mapper;
    }

    public async Task<YellowPages.Shared.Dtos.Response<LocationInformationDto>> CreateAsync(
        LocationInformationCreateDto locationInformationCreateDto)
    {
        var model = _mapper.Map<LocationInformation>(locationInformationCreateDto);


        var locations =
            await IAsyncCursorSourceExtensions.ToListAsync(
                IMongoCollectionExtensions.Find(_locationInformationCollection, a => true));

        if (!locations.Any())
        {
            await _locationInformationCollection.InsertOneAsync(model);
            return YellowPages.Shared.Dtos.Response<LocationInformationDto>.Success(
                _mapper.Map<LocationInformationDto>(model), 200);
        }

        var locationX = locations.Where(x => x.Location == model.Location&& x.ContactId== model.ContactId);

        if (!locationX.Any())
        {
            await _locationInformationCollection.InsertOneAsync(model);
            return YellowPages.Shared.Dtos.Response<LocationInformationDto>.Success(
                _mapper.Map<LocationInformationDto>(model), 200);
        }
        return YellowPages.Shared.Dtos.Response<LocationInformationDto>.Fail(
            "Can not added ", 404);

    }


    public async Task<YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>> DeleteAsync(string id)
    {
        var result = await IMongoCollectionExtensions.DeleteOneAsync(_locationInformationCollection, x => x.Id == id);

        if (result.DeletedCount > 0)
            return YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>.Success(204);
        return YellowPages.Shared.Dtos.Response<YellowPages.Shared.Dtos.NoContent>.Fail("Location not found", 404);
    }
}