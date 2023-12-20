

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

            CreateMap<UserEntity, UserModel>();
        }
    }
}
