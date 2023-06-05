namespace YellowPagesService.Mapping;

public class GeneralMapping : AutoMapper.Profile
{
    public GeneralMapping()
    {
        CreateMap<YellowPagesService.Models.YellowPagesReport, YellowPagesService.Dtos.YellowPagesReportCreateDto>()
            .ReverseMap();

        CreateMap<YellowPagesService.Models.YellowPagesReport, YellowPagesService.Dtos.YellowPagesReportDto>()
            .ReverseMap();

        CreateMap<YellowPagesService.Models.LocationInformation, YellowPagesService.Dtos.LocationInformationDto>()
            .ReverseMap();

        CreateMap<YellowPagesService.Models.PhoneInformation, YellowPagesService.Dtos.PhoneInformationDto>()
            .ReverseMap();
    }
}