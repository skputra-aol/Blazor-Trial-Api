using AutoMapper;
using BlazorApp.DTO;
using BlazorApp.Models;
using BlazorApp.Helpers;

namespace BlazorApp.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.firstName,
                opt => opt.MapFrom(src => src.firstname))
                .ForMember(dest => dest.lastName,
                opt => opt.MapFrom(src => src.lastname))
                .ForMember(dest => dest.email,
                opt => opt.MapFrom(src => src.email));
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.firstname,
                opt => opt.MapFrom(src => src.firstName))
                .ForMember(dest => dest.lastname,
                opt => opt.MapFrom(src => src.lastName))
                .ForMember(dest => dest.fullname,
                opt => opt.MapFrom(src => string.Concat(src.firstName," ",src.lastName)));
        }
    }
}