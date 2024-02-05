using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace StoreApp.Infrastructure.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion,Product>();
            //reversemap ile hem productdtoforupdate den product a ve product tan productdtoforupdate ye geçiş sağlar
            CreateMap<ProductDtoForUpdate,Product>().ReverseMap();
        }
    }
}