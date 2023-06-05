namespace YellowPagesService.Mapping;

public class GeneralMapping : AutoMapper.Profile
{
    public GeneralMapping()
    {
        CreateMap<YellowPagesService.Models.YellowPages, YellowPagesService.Dtos.YellowPagesDto>()
            .ForMember(dest => dest.EMailInformations, opt => opt.MapFrom(src => src.EMailInformation))
            .ForMember(dest => dest.PhoneInformations, opt => opt.MapFrom(src => src.PhoneInformation))
            .ForMember(dest => dest.LocationInformations, opt => opt.MapFrom(src => src.LocationInformation))
            .ReverseMap();

        CreateMap<YellowPagesService.Models.YellowPages, YellowPagesService.Dtos.YellowPagesCreateDto>().ReverseMap();

        CreateMap<YellowPagesService.Models.EMailInformation, YellowPagesService.Dtos.EMailInformationDto>().ReverseMap();
        CreateMap<YellowPagesService.Models.EMailInformation, YellowPagesService.Dtos.EMailInformationCreateDto>()
            .ReverseMap();

        CreateMap<YellowPagesService.Models.LocationInformation, YellowPagesService.Dtos.LocationInformationDto>()
            .ReverseMap();
        CreateMap<YellowPagesService.Models.LocationInformation, YellowPagesService.Dtos.LocationInformationCreateDto>()
            .ReverseMap
                ();

        CreateMap<YellowPagesService.Models.PhoneInformation, YellowPagesService.Dtos.PhoneInformationDto>().ReverseMap();
        CreateMap<YellowPagesService.Models.PhoneInformation, YellowPagesService.Dtos.PhoneInformationCreateDto>()
            .ReverseMap();
    }
}