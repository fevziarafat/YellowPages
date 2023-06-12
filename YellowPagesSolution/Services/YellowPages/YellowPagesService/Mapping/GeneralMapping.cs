using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;

namespace YellowPagesService.Mapping;

public class GeneralMapping : AutoMapper.Profile
{
    public GeneralMapping()
    {
        CreateMap<YellowPages.Shared.Models.YellowPage, YellowPagesDto>()
            .ForMember(dest => dest.EMailInformations, opt => opt.MapFrom(src => src.EMailInformation))
            .ForMember(dest => dest.PhoneInformations, opt => opt.MapFrom(src => src.PhoneInformation))
            .ForMember(dest => dest.LocationInformations, opt => opt.MapFrom(src => src.LocationInformation))
            .ReverseMap();

        CreateMap<YellowPages.Shared.Models.YellowPage, YellowPagesCreateDto>().ReverseMap();

        CreateMap<EMailInformation, EMailInformationDto>().ReverseMap();
        CreateMap<EMailInformation, EMailInformationCreateDto>()
            .ReverseMap();

        CreateMap<LocationInformation, LocationInformationDto>()
            .ReverseMap();
        CreateMap<LocationInformation, LocationInformationCreateDto>()
            .ReverseMap
                ();

        CreateMap<PhoneInformation, PhoneInformationDto>().ReverseMap();
        CreateMap<PhoneInformation, PhoneInformationCreateDto>()
            .ReverseMap();
    }
}