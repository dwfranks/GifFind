using AutoMapper;
using GifFind.API.Entities;
using GifFind.API.Models;
using GifFind.API.Models.DTO;

namespace GifFind.API.MapperProfiles
{
    public class CategoryMap : Profile
    {
        public CategoryMap()
        {
            CreateMap<Category, CategoryForGet>()
                .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.CategoryID))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.SavedImages, opt => opt.MapFrom(src => src.SavedImages))
                .ReverseMap();


            CreateMap<CategoryForCreate, Category>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName));


            CreateMap<GifImage, SavedImage>()
                .ForMember(dest => dest.saved_original, opt => opt.MapFrom(src => src.original))
                .ForMember(dest => dest.saved_original_still, opt => opt.MapFrom(src => src.original_still))
                .ForMember(dest => dest.saved_previewGif, opt => opt.MapFrom(src => src.previewGif))
                .ReverseMap();


            CreateMap<Original, SavedOriginal>()
                .ForMember(dest => dest.saved_image, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<OriginalStill, SavedOriginalStill>()
                .ForMember(dest => dest.saved_image, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PreviewGif, SavedPreviewGif>()
                .ForMember(dest => dest.saved_image, opt => opt.Ignore())
                .ReverseMap();


        }
    }
}