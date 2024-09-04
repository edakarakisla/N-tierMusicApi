using AutoMapper;
using Music.Api.DTO;
using Music.Core.Model;

namespace Music.Api.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Track, MusicDetail>().ReverseMap();
            CreateMap<Artist, ArtistDTO>().ReverseMap();
            CreateMap<SaveMusic, Track>();
            CreateMap<SaveArtistDTO, Artist>();
        }
    }
}
