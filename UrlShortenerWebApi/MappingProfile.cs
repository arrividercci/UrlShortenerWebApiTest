using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace UrlShortenerWebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IConfiguration configuration)
        {
            CreateMap<Url, UrlDto>()
                .ForMember(urlDto => urlDto.ShorterUrl, opt => opt.MapFrom(url => string.Join("", configuration.GetSection("BaseUrl"), "/",url.ShorterUrl)));

            CreateMap<UrlForCreationDto, Url>();

            CreateMap<UrlForUpdateDto, Url>();
        }
    }
}
