

using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;

namespace YellowPagesReportService.Mapping;

public class GeneralMapping : AutoMapper.Profile
{
    public GeneralMapping()
    {
        CreateMap<YellowPagesReport, YellowPagesReportCreateDto>().ReverseMap();

        CreateMap<YellowPagesReport, YellowPagesReportDto>().ReverseMap();

        CreateMap<LocationInformation, LocationInformationDto>().ReverseMap();

        CreateMap<PhoneInformation, PhoneInformationDto>().ReverseMap();
    }
}