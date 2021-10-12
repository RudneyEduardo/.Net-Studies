using AutoMapper;
using PlataformService.Dtos;
using PlataformService.Models;

namespace PlataformService.Profiles
{
    public class PlataformsProfile : Profile
    {
        public PlataformsProfile()
        {
            // Source -> Target
            CreateMap<Plataform, PlataformReadDto>();
            CreateMap<PlataformCreateDto, Plataform>();
        }
    }
}