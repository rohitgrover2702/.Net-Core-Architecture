using AutoMapper;
using Kobe.Domain.Dtos;
using Kobe.Domain.Entities;

namespace Kobe.Service.MappingDtos
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() => CreateMap<Country, CountryDTO>();
    }
}
