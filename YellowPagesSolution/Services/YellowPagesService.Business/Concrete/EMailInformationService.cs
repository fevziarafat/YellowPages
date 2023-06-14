using AutoMapper;
using YellowPages.Data.Abstract;
using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;
using YellowPagesService.Business.Abstract;

namespace YellowPagesService.Business.Concrete;

public class EMailInformationService : IEMailInformationService
{
    private readonly IEMailInformationDal _eMailInformationDal;

    private readonly IMapper _mapper;

    public EMailInformationService(IMapper mapper,
        IEMailInformationDal eMailInformationDal)
    {
        _mapper = mapper;
        _eMailInformationDal = eMailInformationDal;
    }

    public async Task<Response<EMailInformationDto>> CreateAsync(
        EMailInformationCreateDto eMailInformationCreateDto)
    {
        var model = _mapper.Map<EMailInformation>(eMailInformationCreateDto);

        var eMails = _eMailInformationDal.Get().ToList();


        if (!eMails.Any())
        {
            await _eMailInformationDal.AddAsync(model);
            return Response<EMailInformationDto>.Success(
                _mapper.Map<EMailInformationDto>(model), 200);
        }

        var eMailX = eMails.Where(x => x.EMail == model.EMail && x.ContactId == model.ContactId);

        if (!eMailX.Any())
        {
            await _eMailInformationDal.AddAsync(model);
            return Response<EMailInformationDto>.Success(
                _mapper.Map<EMailInformationDto>(model), 200);
        }

        return Response<EMailInformationDto>.Fail(
            "Can not added ", 404);
    }


    public async Task<Response<NoContent>> DeleteAsync(string id)
    {
        var result = await _eMailInformationDal.DeleteAsync(x => x.Id == id);
        if (result.EMail != null)
            return Response<NoContent>.Success(204);
        return Response<NoContent>.Fail("Contact not found", 404);
    }
}