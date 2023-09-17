using AutoMapper;
using BlazorApp.DTO;
using BlazorApp.Models;

namespace BlazorApp.Profiles
{
    public class OrganizerProfile : Profile
    {
        public OrganizerProfile()
        {

            CreateMap<Organizer, OrganizerDto>()
                .ForMember(dest => dest.name,
                opt => opt.MapFrom(src => src.organizerName))
                .ForMember(dest => dest.imglocation,
                opt => opt.MapFrom(src => src.imageLocation));

            CreateMap<OrganizerDto, Organizer>()
                .ForMember(dest => dest.organizerName,
                opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.imageLocation,
                opt => opt.MapFrom(src => src.imglocation));

        }
    }
}
