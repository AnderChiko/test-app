using AutoMapper;
using Test.BusinessLogic.Models;

namespace Test.BusinessLogic.Configuration.AutoMapper
{
    public class ServiceContextMapperProfile : Profile
    {
        public ServiceContextMapperProfile()
        {

            CreateMap<User, Context.User>().ReverseMap();

            CreateMap<ProductPrice, Context.ProductPrice>().ReverseMap();
            CreateMap<Product, Context.Product>()
                 .ForMember(i => i.ProductPrice, src => src.MapFrom(i => i.ProductPrice))
                 .ReverseMap();

            CreateMap<OrderItems, Context.OrderItems>().ReverseMap();
            CreateMap<Order, Context.Order>()
                  .ForMember(i => i.OrderItems, src => src.MapFrom(i => i.OrderItems))
                  .ReverseMap();
        }
    }
}