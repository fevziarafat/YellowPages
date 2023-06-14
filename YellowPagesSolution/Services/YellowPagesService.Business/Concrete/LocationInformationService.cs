using AutoMapper;
using YellowPages.Data.Abstract;
using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;
using YellowPagesService.Business.Abstract;

namespace YellowPagesService.Business.Concrete;

public class LocationInformationService : ILocationInformationService
{
    private readonly ILocationInformationDal _locationInformationDal;
    private readonly IMapper _mapper;

    public LocationInformationService(
        IMapper mapper,
        ILocationInformationDal locationInformationDal)
    {
        _mapper = mapper;
        _locationInformationDal = locationInformationDal;
    }

    public async Task<Response<LocationInformationDto>> CreateAsync(
        LocationInformationCreateDto locationInformationCreateDto)
    {
        var model = _mapper.Map<LocationInformation>(locationInformationCreateDto);

        var locations = _locationInformationDal.Get().ToList();

        if (!locations.Any())
        {
            await _locationInformationDal.AddAsync(model);
            return Response<LocationInformationDto>.Success(
                _mapper.Map<LocationInformationDto>(model), 200);
        }

        var locationX = locations.Where(x => x.Location == model.Location && x.ContactId == model.ContactId);

        if (!locationX.Any())
        {
            await _locationInformationDal.AddAsync(model);
            return Response<LocationInformationDto>.Success(
                _mapper.Map<LocationInformationDto>(model), 200);
        }

        return Response<LocationInformationDto>.Fail(
            "Can not added ", 404);
    }


    public async Task<Response<NoContent>> DeleteAsync(string id)
    {
        var result = await _locationInformationDal.DeleteAsync(x => x.Id == id);

        if (result.ContactId != null)
            return Response<NoContent>.Success(204);
        return Response<NoContent>.Fail("Location not found", 404);
    }
}