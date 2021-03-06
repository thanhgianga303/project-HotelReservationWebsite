using AutoMapper;
using BookingAPI.Models;
using MessageTypes.BookingService;

namespace BookingAPI.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingItemDTO, BookingItem>();
            CreateMap<BookingItem, BookingItemDTO>();
            CreateMap<BookingDTO, Booking>();
            CreateMap<Booking, BookingDTO>();
            CreateMap<Booking, CreateBookingMessage>();
            // CreateMap<BookingDTO, CreateBookingMessage>();
        }
    }
}