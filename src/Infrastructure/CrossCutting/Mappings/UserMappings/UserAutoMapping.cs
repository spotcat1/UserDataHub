

using AutoMapper;
using Domain.Models;
using Application.Helper;

namespace Infrastructure.CrossCutting.Mappings.UserMappings
{
    public class UserAutoMapping : Profile
    {
        public UserAutoMapping()
        {
            CreateMap<UserModel, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ConvertToMiladi()));

            CreateMap<UserEntity, UserModel>()
                .ForMember(dest => dest.ImageId, opt => opt.MapFrom(src => src.ImagePath))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ConvertToPersianDate()))
                .ForMember(dest => dest.UserGenderName, opt => opt.MapFrom(src => src.GenderId != Guid.Empty ? src.Gender.Title:""));


            
        }
    }

}

