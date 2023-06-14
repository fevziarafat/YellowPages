using AutoMapper;
using YellowPages.Data.Abstract;
using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;
using YellowPages.Shared.Settings;
using YellowPagesService.Business.Abstract;

namespace YellowPagesService.Business.Concrete;

public class YellowPagesService : IYellowPagesService
{
    private readonly IEMailInformationDal _eMailInformationDal;

    private readonly ILocationInformationDal _locationInformationDal;


    private readonly IMapper _mapper;
    private readonly IPhoneInformationDal _phoneInformationDal;
    private readonly IYellowPagesDal _yellowPagesDal;

    public YellowPagesService(IMapper mapper, IDatabaseSettings databaseSettings,
        IPhoneInformationDal phoneInformationDal, ILocationInformationDal locationInformationDal,
        IEMailInformationDal eMailInformationDal, IYellowPagesDal yellowPagesDal)
    {
        _mapper = mapper;
        _phoneInformationDal = phoneInformationDal;
        _locationInformationDal = locationInformationDal;
        _eMailInformationDal = eMailInformationDal;
        _yellowPagesDal = yellowPagesDal;
    }

    //Rehberde kişi oluşturma
    public async Task<Response<YellowPagesDto>> CreateAsync(
        YellowPagesCreateDto yellowPagesCreateDto)
    {
        var model = _mapper.Map<YellowPage>(yellowPagesCreateDto);

        var contacts = _yellowPagesDal.Get().ToList();


        if (!contacts.Any())
        {
            await _yellowPagesDal.AddAsync(model);
            return Response<YellowPagesDto>.Success(
                _mapper.Map<YellowPagesDto>(model), 200);
        }

        var contactsX = contacts.Where(x => x.Name == model.Name);

        if (!contactsX.Any())
        {
            await _yellowPagesDal.AddAsync(model);
            return Response<YellowPagesDto>.Success(
                _mapper.Map<YellowPagesDto>(model), 200);
        }

        return Response<YellowPagesDto>.Fail(
            "Can not added ", 404);
    }

    //Rehberdeki kişilerin listelenmesi
    public async Task<Response<List<YellowPagesDto>>> GetAllAsync()
    {
        var yellowPages = _yellowPagesDal.Get().ToList();

        if (yellowPages.Any())
            foreach (var yellowPage in yellowPages)
            {
                yellowPage.EMailInformation = _eMailInformationDal.Get(x => x.ContactId == yellowPage.Id).ToList();

                yellowPage.LocationInformation =
                    _locationInformationDal.Get(x => x.ContactId == yellowPage.Id).ToList();
                yellowPage.PhoneInformation = _phoneInformationDal.Get(x => x.ContactId == yellowPage.Id).ToList();
            }

        return Response<List<YellowPagesDto>>.Success(
            _mapper.Map<List<YellowPagesDto>>(yellowPages), 200);
    }

    //Rehberde kişi kaldırma
    public async Task<Response<NoContent>> DeleteAsync(string id)
    {
        var result = await _yellowPagesDal.DeleteAsync(x => x.Id == id);

        if (result.Id != null)
            return Response<NoContent>.Success(204);
        return Response<NoContent>.Fail("Contact not found", 404);
    }

    //Rehberdeki bir kişiye ait iletişim bilgilerinin de yer aldığı detay bilgilerinin getirilmesi
    public async Task<Response<YellowPagesDto>>
        GetAllInformationByUserIdAsync(string id)
    {
        var contact = _yellowPagesDal.Get(x => x.Id == id).FirstOrDefault();

        var eMailInformationCollections = _eMailInformationDal.Get(x => x.ContactId == id).ToList();

        var locationInformationCollection = _locationInformationDal.Get(x => x.ContactId == id).ToList();

        var phoneInformationCollection = _phoneInformationDal.Get(x => x.ContactId == id).ToList();


        contact.EMailInformation = eMailInformationCollections;
        contact.LocationInformation = locationInformationCollection;
        contact.PhoneInformation = phoneInformationCollection;

        return Response<YellowPagesDto>.Success(
            _mapper.Map<YellowPagesDto>(contact), 200);
    }
}