using AutoMapper;
using ClubSystemsTest.Models;
using ClubSystemsTest.Models.Dto;

namespace ClubSystemsTest
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDetailsDto, UserDetails>().ReverseMap();
                config.CreateMap<MembershipDetailsDto, MembershipDetails>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
