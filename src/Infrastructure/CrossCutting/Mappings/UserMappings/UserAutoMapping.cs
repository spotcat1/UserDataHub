

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
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.GenderId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.IdentityCode, opt => opt.MapFrom(src => src.IdentityCode))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ConvertToPersianDate()))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality))
                .ForMember(dest => dest.ImageId, opt => opt.MapFrom(src => src.ImagePath))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.GenderEntityTitle, opt => opt.MapFrom(src => src.GenderId  != Guid.Empty ? src.Gender.Title : ""));




        }
    }

}

