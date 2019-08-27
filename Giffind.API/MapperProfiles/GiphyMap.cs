using AutoMapper;
using GifFind.API.Entities;
using GifFind.API.Models;
using GifFind.API.Models.DTO;

namespace GifFind.API.MapperProfiles
{
    public class GiphyMap : Profile
    {
        public GiphyMap()
        {
            CreateMap<RootObject, GifPackage>()
                .ForMember(dest => dest.gifImages, opt => opt.MapFrom(src => src.data))
                .ForMember(dest => dest.pagination, opt => opt.MapFrom(src => src.pagination));

            CreateMap<Data, GifImage>()
                .ForMember(dest => dest.id, opt => opt.Ignore())
                .ForMember(dest => dest.categoryid, opt => opt.Ignore())
                .ForMember(dest => dest.imageid, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.source_url, opt => opt.MapFrom(src => src.url))
                .ForMember(dest => dest.orgin_url, opt => opt.MapFrom(src => src.source))
                .ForMember(dest => dest.original, opt => opt.MapFrom(src => src.images.original))
                .ForMember(dest => dest.original_still, opt => opt.MapFrom(src => src.images.original_still))
                .ForMember(dest => dest.previewGif, opt => opt.MapFrom(src => src.images.preview_gif));
        }
    }
}