using AutoMapper;
using LookAndRate.DataAccess.Entity;
using LookAndRate.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookAndRate.API_Angular.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Photo, PhotoDTO>().ReverseMap();
        }
    }
}
