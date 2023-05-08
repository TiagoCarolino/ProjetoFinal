using AutoMapper;

namespace ProjetoFinalAPI.Handlers
{
    public class ProductsMappingProfile : Profile
    {
        public ProductsMappingProfile()
        {
            CreateMap<ProjetoFinalAPI.Models.Product, ProjetoFinalAPI.Models.Product>()
                .ForMember(dest => dest.Id, dest => dest.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, dest => dest.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, dest => dest.MapFrom(src => src.Description))
                .ForMember(dest => dest.CategoryId, dest => dest.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Price, dest => dest.MapFrom(src => src.Price))
                .ForMember(dest => dest.IsDeleted, dest => dest.MapFrom(src => src.IsDeleted));
        }
    }
}
