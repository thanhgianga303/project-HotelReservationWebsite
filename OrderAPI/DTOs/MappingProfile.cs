using AutoMapper;
using OrderAPI.Models;

namespace OrderAPI.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderItemDTO, OrderItem>();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();
        }
    }
}