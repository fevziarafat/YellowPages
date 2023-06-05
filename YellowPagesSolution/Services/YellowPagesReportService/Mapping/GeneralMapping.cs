namespace YellowPagesReportService.Mapping;

public class GeneralMapping : AutoMapper.Profile
{
    public GeneralMapping()
    {
        CreateMap<YellowPagesReportService.Models.YellowPages, YellowPagesReportService.Dtos.YellowPagesDto>()
            .ForMember(dest => dest.EMailInformations, opt => opt.MapFrom(src => src.EMailInformation))
            .ForMember(dest => dest.PhoneInformations, opt => opt.MapFrom(src => src.PhoneInformation))
            .ForMember(dest => dest.LocationInformations, opt => opt.MapFrom(src => src.LocationInformation))
            .ReverseMap();

        CreateMap<YellowPagesReportService.Models.YellowPages, YellowPagesReportService.Dtos.YellowPagesCreateDto>()
            .ReverseMap();

        CreateMap<YellowPagesReportService.Models.EMailInformation, YellowPagesReportService.Dtos.EMailInformationDto>()
            .ReverseMap();

        CreateMap<YellowPagesReportService.Models.EMailInformation,
                YellowPagesReportService.Dtos.EMailInformationCreateDto>()
            .ReverseMap();

        CreateMap<YellowPagesReportService.Models.LocationInformation,
                YellowPagesReportService.Dtos.LocationInformationDto>()
            .ReverseMap();

        CreateMap<YellowPagesReportService.Models.LocationInformation,
                YellowPagesReportService.Dtos.LocationInformationCreateDto>()
            .ReverseMap
                ();

        CreateMap<YellowPagesReportService.Models.PhoneInformation, YellowPagesReportService.Dtos.PhoneInformationDto>()
            .ReverseMap();

        CreateMap<YellowPagesReportService.Models.PhoneInformation,
                YellowPagesReportService.Dtos.PhoneInformationCreateDto>()
            .ReverseMap();
    }
}