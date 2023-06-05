using YellowPagesReportService.Dtos;
using YellowPagesReportService.Models;

namespace YellowPagesReportService.Mapping;

public class GeneralMapping : AutoMapper.Profile
{
    public GeneralMapping()
    {
        CreateMap<YellowPagesReportService.Models.YellowPagesReport, YellowPagesReportCreateDto>().ReverseMap();

        CreateMap<YellowPagesReport, YellowPagesReportDto>().ReverseMap();

        CreateMap<YellowPagesReportService.Models.LocationInformation, YellowPagesReportService.Dtos.LocationInformationDto>().ReverseMap();

        CreateMap<YellowPagesReportService.Models.PhoneInformation, YellowPagesReportService.Dtos.PhoneInformationDto>().ReverseMap();
    }
}