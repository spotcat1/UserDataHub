

using AutoMapper;
using Domain.Models;

namespace Infrastructure.CrossCutting.Mappings.UserMappings
{
    public class UserAutoMapping:Profile
    {
        public UserAutoMapping()
        {
            CreateMap<UserModel, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<UserEntity, UserModel>()
                .ForMember(dest => dest.ImageId, opt => opt.MapFrom(src => src.ImagePath))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
