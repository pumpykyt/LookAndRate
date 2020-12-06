using AutoMapper;
using Project_P34.DataAccess.Entity;
using Project_P34.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_P34.API_Angular.MappingProfiles
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
