using AutoMapper;
using YellowPages.Data.Abstract;
using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;
using YellowPagesReportService.Business.Abstract;

namespace YellowPagesReportService.Business.Concrete;

public class YellowPagesReportService : IYellowPagesReportService
{
    private readonly IEMailInformationDal _eMailInformationDal;
    private readonly ILocationInformationDal _locationInformationDal;
    private readonly IMapper _mapper;
    private readonly IPhoneInformationDal _phoneInformationDal;
    private readonly IYellowPagesDal _yellowPagesDal;
    private readonly IYellowPagesReportDal _yellowPagesReportDal;


    public YellowPagesReportService(IMapper mapper,
        IPhoneInformationDal phoneInformationDal, ILocationInformationDal locationInformationDal,
        IEMailInformationDal eMailInformationDal, IYellowPagesDal yellowPagesDal,
        IYellowPagesReportDal yellowPagesReportDal)
    {
        _mapper = mapper;
        _phoneInformationDal = phoneInformationDal;
        _locationInformationDal = locationInformationDal;
        _eMailInformationDal = eMailInformationDal;
        _yellowPagesDal = yellowPagesDal;
        _yellowPagesReportDal = yellowPagesReportDal;
    }

    //Rapor oluşturma
    public async Task<Response<YellowPagesReportDto>> CreateAsync(
        string locationName)
    {
        var yellowReportCreateDto = new YellowPagesReportCreateDto();
        yellowReportCreateDto.Location = locationName;
        var model = _mapper.Map<YellowPagesReport>(yellowReportCreateDto);

        var locations = _locationInformationDal.Get().ToList();
        var yellowPages = _yellowPagesDal.Get().ToList();
        var phones = _phoneInformationDal.Get().ToList();

        var yellowPagesCount = 0;
        var phoneCount = 0;
        var contactGuidList = new List<string>();

        if (locations.Any())
            foreach (var location in locations)
                if (location.Location == yellowReportCreateDto.Location)
                {
                    var personId = location.ContactId;

                    foreach (var contact in yellowPages)
                        if (contact.Id == personId)
                            if (!contactGuidList.Contains(personId))
                            {
                                contactGuidList.Add(personId);
                                yellowPagesCount++;
                            }

                    foreach (var phone in phones)
                        if (phone.ContactId == personId)
                            phoneCount++;
                }

        model.Location = yellowReportCreateDto.Location;
        model.LocationContactCount = yellowPagesCount;
        model.LocationPhoneCount = phoneCount;
        model.CreatedTime = DateTime.Now;


        await _yellowPagesReportDal.AddAsync(model);
        return Response<YellowPagesReportDto>.Success(
            _mapper.Map<YellowPagesReportDto>(model), 200);
    }

    //Rapor listelenmesi
    public async Task<Response<List<YellowPagesReportDto>>> GetAllAsync()
    {
        var yellowReports = _yellowPagesReportDal.Get().ToList();

        return Response<List<YellowPagesReportDto>>.Success(
            _mapper.Map<List<YellowPagesReportDto>>(yellowReports), 200);
    }

    public async Task<Response<YellowPagesReportDto>> GetReportByIdAsync(string id)
    {
        var yellowReports = _yellowPagesReportDal.Get(x => x.Id == id).FirstOrDefault();
        return Response<YellowPagesReportDto>.Success(
            _mapper.Map<YellowPagesReportDto>(yellowReports), 200);
    }
}