using AutoMapper;
using YellowPages.Data.Abstract;
using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;
using YellowPages.Shared.Settings;
using YellowPagesService.Business.Abstract;

namespace YellowPagesService.Business.Concrete;

public class PhoneInformationService : IPhoneInformationService
{
    private readonly IMapper _mapper;

    private readonly IPhoneInformationDal _phoneInformationDal;


    public PhoneInformationService(IMapper mapper,
        IDatabaseSettings databaseSettings, IPhoneInformationDal phoneInformationDal)
    {
        _mapper = mapper;
        _phoneInformationDal = phoneInformationDal;
    }

    public async Task<Response<PhoneInformationDto>> CreateAsync(
        PhoneInformationCreateDto phoneInformationCreateDto)
    {
        var model = _mapper.Map<PhoneInformation>(phoneInformationCreateDto);

        var phones = _phoneInformationDal.Get().ToList();


        if (!phones.Any())
        {
            await _phoneInformationDal.AddAsync(model);
            return Response<PhoneInformationDto>.Success(
                _mapper.Map<PhoneInformationDto>(model), 200);
        }

        var phoneX = phones.Where(x => x.Phone == model.Phone && x.ContactId == model.ContactId);

        if (!phoneX.Any())
        {
            await _phoneInformationDal.AddAsync(model);
            return Response<PhoneInformationDto>.Success(
                _mapper.Map<PhoneInformationDto>(model), 200);
        }

        return Response<PhoneInformationDto>.Fail(
            "Can not added", 404);
    }


    public async Task<Response<NoContent>> DeleteAsync(string id)
    {
        var result = await _phoneInformationDal.DeleteAsync(x => x.Id == id);

        if (result.ContactId != null)
            return Response<NoContent>.Success(204);
        return Response<NoContent>.Fail("Phone not found", 404);
    }
}