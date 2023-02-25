using AutoMapper;
using Schowek.Library.DTOs;
using Schowek.Library.Models;

namespace SchowekAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Catalog, CatalogDTO>();
            CreateMap<CreateCatalogDTO, Catalog>();
            CreateMap<Item, ItemDTO>();
            CreateMap<CreateItemDTO, Item>();
        }
    }
}