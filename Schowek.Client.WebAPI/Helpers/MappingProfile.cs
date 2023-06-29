using AutoMapper;
using Schowek.Shared.Core.DTOs;
using Schowek.Shared.Core.Models;

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