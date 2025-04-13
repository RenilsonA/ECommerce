using System.ComponentModel;
using AutoMapper;

namespace EFlowers_Products.Implementation
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
