using Application.Helper;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CrossCutting.Mappings.CarMappings
{
    public class CarAutoMapping:Profile
    {
        public CarAutoMapping()
        {
            CreateMap<CarModel, CarEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ConvertToMiladi()));
            
        }
    }
}
